#region Copyright © 2014 Denis Korkhov, Oxagile (http://www.oxagile.com/)
// /*
//  * All rights reserved. This program and the accompanying materials
//  * are made available under the terms of the GNU Lesser General Public License
//  * (LGPL) version 2.1 which accompanies this distribution, and is available at
//  * http://www.gnu.org/licenses/lgpl-2.1.html
//  *
//  *  Filename:	WindsorToolContainer.cs
//  *  Date:		05/02/2014
//  *  Author:   	Denis Korkhov
//  *
//  */
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Cortoxa.IoC;
using Cortoxa.IoC.Dependency;
using Cortoxa.IoC.Registration;
using Cortoxa.Windsor.Interceptions;

namespace Cortoxa.Windsor
{
    internal sealed class WindsorToolContainer : IToolContainer
    {
        private readonly IWindsorContainer container;
        private readonly IList<IDependencyProvider> providers = new List<IDependencyProvider>();

        public WindsorToolContainer(IWindsorContainer container)
        {
            this.container = container;
        }

        public T GetContainer<T>()
        {
            return (T) container;
        }

        public IToolContainer Register<T>(Action<T> registration)
        {
            var container = GetContainer<T>();
            registration(container);
            return this;
        }

        public T Resolve<T>(object arguments = null)
        {
            return arguments != null ? container.Resolve<T>(arguments) : container.Resolve<T>();
        }

        public object Resolve(Type type, object arguments = null)
        {
            return arguments != null ? container.Resolve(type, arguments) : container.Resolve(type);
        }

        public T Resolve<T>(Type type, object arguments = null)
        {
            var result = arguments != null ? container.Resolve(type, arguments) : container.Resolve(type);
            return (T)result;
        }

        public T Resolve<T>(string key, object arguments = null)
        {
            return container.Resolve<T>(key, arguments);
        }

        public T[] ResolveAll<T>(object arguments = null)
        {
            return arguments != null ? container.ResolveAll<T>(arguments) : container.ResolveAll<T>();
        }

        public object[] ResolveAll(Type type, object arguments = null)
        {
            var tmp = container.ResolveAll(type);

            return arguments != null ? container.ResolveAll(type, arguments).Cast<object>().ToArray() : container.ResolveAll(type).Cast<object>().ToArray();
        }

        public T[] ResolveAll<T>(Type type, object arguments = null)
        {
            return arguments != null ? container.ResolveAll(type, arguments).Cast<T>().ToArray() : container.ResolveAll(type).Cast<T>().ToArray();
            
        }

        public T[] ResolveAll<T>(string key, object arguments = null)
        {
            throw new NotImplementedException();
        }

        public IToolContainer Register(Action<IToolRegistration> registration)
        {
            var instance = ToolRegistration.Types;
            registration(instance);
            return Register(instance);
        }

        public IToolContainer Register(params IToolRegistration[] registrations)
        {
            if (registrations != null && registrations.Length > 0)
            {
                foreach (var registration in registrations)
                {
                    var context = registration.Context;
                    if (context.Assemblies != null && context.Assemblies.Any())
                    {
                        foreach (var assembly in context.Assemblies)
                        {
                            var types = Types.FromAssembly(assembly).Where(t => (string.IsNullOrEmpty(context.Namespace) || t.Namespace == context.Namespace) && (context.BasedOn == null || t.IsInstanceOfType(context.BasedOn) || t.IsSubclassOf(context.BasedOn)));
                            types.ToWindsorLifeTime(context.Lifetime);
                            container.Register(types);
                        }
                    }
                    else
                    {
                        ComponentRegistration<object> component = Component.For(context.For);

                        if (context.ToFactory != null)
                        {
                            component = component.UsingFactoryMethod((k, cm, c) => context.ToFactory(new FactoryContext()
                            {
                                RequestedType = c.RequestedType,
                                Arguments = c.HasAdditionalArguments ? c.AdditionalArguments.Values.Cast<object>().ToArray() : null
                            }), true);
                        }
                        else
                        {
                            component = component.ImplementedBy(context.To);
                        }

                        component = component.ToWindsorLifeTime(context.Lifetime);
                        
                        if (!string.IsNullOrEmpty(context.Name))
                        {
                            component = component.Named(context.Name);
                        }

                        if (context.Dependencies.Any())
                        {

                            var allDependencies = context.Dependencies.Select(dependency=>Dependency.OnComponent(dependency.Key, dependency.Value)).ToArray();
                            component.DependsOn(allDependencies);
                        }
                    
                        if (context.Interceptors.Any())
                        {
                            var interceptorName = string.Format("interceptor_{0}_{1}", context.For.Name, Guid.NewGuid().ToString().Replace("-", string.Empty));
                            //Register interceptor itself by name
                            container.Register(Component.For<RegistrationInterceptor>().Named(interceptorName)
                                .DynamicParameters((k, c, p) =>
                                {
                                    p["context"] = c;
                                    return null;
                                })
                                .DependsOn(
                                    Dependency.OnValue("interceptions", context.Interceptors),
                                    Dependency.OnValue("container", this),
                                    Dependency.OnValue("context", null)
                                ).LifestyleTransient()
                                );
                            component.Interceptors(interceptorName);
                        }
                        container.Register(component);
                    }
                    
                }
            }
            return this;
        }

        public void Release(object instance)
        {
            container.Release(instance);
        }

        public void AddDependencyProvider(IDependencyProvider provider)
        {
            providers.Add(provider);
        }
    }
}
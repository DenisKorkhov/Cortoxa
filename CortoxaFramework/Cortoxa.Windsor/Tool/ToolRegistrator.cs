#region Copyright © 2014 Denis Korkhov, Oxagile (http://www.oxagile.com/)
// /*
//  * All rights reserved. This program and the accompanying materials
//  * are made available under the terms of the GNU Lesser General Public License
//  * (LGPL) which accompanies this distribution, and is available at
//  * http://www.gnu.org/licenses/lgpl.html
//  *
//  *  Filename:	ToolRegistrator.cs
//  *  Date:		21/02/2014
//  *  Author:   	Denis Korkhov
//  *
//  */
#endregion

using System;
using System.Linq;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Cortoxa.Components;
using Cortoxa.IoC;
using Cortoxa.IoC.Base;
using Cortoxa.IoC.Factory;
using Cortoxa.IoC.Service;
using Cortoxa.Windsor.Helpers;
using Cortoxa.Windsor.Interceptions;

namespace Cortoxa.Windsor.Tool
{
    internal class ToolRegistrator : IToolRegistrator
    {
        private readonly IWindsorContainer container;

        public ToolRegistrator(IWindsorContainer container)
        {
            this.container = container;
        }

        public IToolRegistrator Service(params ServiceContext[] services)
        {
            if (services != null)
            {
                foreach (var context in services)
                {
                    Castle.MicroKernel.Registration.ComponentRegistration<object> component = Castle.MicroKernel.Registration.Component.For(context.For);

                        if (context.ToFactory != null)
                        {
                            ServiceContext ctx = context;
                            component = component.UsingFactoryMethod((k, cm, c) => ctx.ToFactory(new FactoryContext
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
                            var allDependencies = context.Dependencies.Select(dependency => Dependency.OnComponent(dependency.Key, dependency.Value)).ToArray();
                            component.DependsOn(allDependencies);
                        }

                        if (context.Interceptors.Any())
                        {
                            var interceptorName = string.Format("interceptor_{0}_{1}", context.For.First().Name, Guid.NewGuid().ToString().Replace("-", string.Empty));
                            //Register interceptor itself by name
                            container.Register(Castle.MicroKernel.Registration.Component.For<RegistrationInterceptor>().Named(interceptorName)
                                .DynamicParameters((k, c, p) =>
                                {
                                    p["context"] = c;
                                    return null;
                                })
                                .DependsOn(
                                    Dependency.OnValue("interceptions", context.Interceptors),
                                    Dependency.OnValue("container", container),
                                    Dependency.OnValue("context", null)
                                ).LifestyleTransient()
                                );
                            component.Interceptors(interceptorName);
                        }
                        container.Register(component);
                }
            }
            return this;
        }

        public IToolRegistrator Component<T>(Action<IToolComponent<T>> action)
        {
            var component = new ToolComponent<T>();
            action(component);
            return this;
        }
    }
}
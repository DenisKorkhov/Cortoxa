#region Copyright © 2014 Denis Korkhov, Oxagile (http://www.oxagile.com/)
// /*
//  * All rights reserved. This program and the accompanying materials
//  * are made available under the terms of the GNU Lesser General Public License
//  * (LGPL) which accompanies this distribution, and is available at
//  * http://www.gnu.org/licenses/lgpl.html
//  *
//  *  Filename:	ServiceBuilder.cs
//  *  Date:		21/02/2014
//  *  Author:   	Denis Korkhov
//  *
//  */
#endregion

using System;
using System.Linq;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Cortoxa.IoC;
using Cortoxa.IoC2;
using Cortoxa.IoC2.Base;
using Cortoxa.IoC2.Service;
using Cortoxa.Windsor.Interceptions;

namespace Cortoxa.Windsor.Service
{
    internal class ServiceBuilder : IServiceBuilder
    {
//        private readonly IToolContainer2 container;
        private readonly RegistrationContext context;

        private ServiceBuilder(RegistrationContext context)
        {
//            this.container = container;
            this.context = context;
        }

//        public static IServiceBuilder For(Type type, IToolContainer2 container)
//        {
////            var context = new RegistrationContext();
////            context.For = type;
//            return new ServiceBuilder(context);
//        }

        /*public IToolContainer2 Done()
        {
            var c = container.Container<IWindsorContainer>();
            ComponentRegistration<object> component = Component.For(context.For);

            if (context.ToFactory != null)
            {
                component = component.UsingFactoryMethod((k, cm, ctx) => context.ToFactory(new FactoryContext
                    {
                        RequestedType = ctx.RequestedType,
                        Arguments = ctx.HasAdditionalArguments ? ctx.AdditionalArguments.Values.Cast<object>().ToArray() : null
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
                var interceptorName = string.Format("interceptor_{0}_{1}", context.For.Name, Guid.NewGuid().ToString().Replace("-", string.Empty));
                //Register interceptor itself by name
                c.Register(Component.For<RegistrationInterceptor>().Named(interceptorName)
                    .DynamicParameters((k, ctx, p) =>
                    {
                        p["context"] = ctx;
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
            c.Register(component);
            return container;
        }
        */
        public IServiceInterception Intercept { get; private set; }

//        public IServiceDependency Depend { get; private set; }

        public IServiceBuilder To<T>()
        {
            return To(typeof (T));
        }

        public IServiceBuilder To(Type type)
        {
            context.To = type;
            return this;
        }

        public IServiceBuilder ToSelf()
        {
            context.To = context.For;
            return this;
        }

        public IServiceBuilder Name(string name)
        {
            context.Name = name;
            return this;
        }

        public RegistrationContext Context { get; private set; }

        public IToolContainer2 Done()
        {
            throw new NotImplementedException();
        }
    }
}
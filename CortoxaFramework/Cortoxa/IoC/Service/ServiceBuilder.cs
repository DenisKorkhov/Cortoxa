#region Copyright © 2014 Denis Korkhov, Oxagile (http://www.oxagile.com/)

// /*
//  * All rights reserved. This program and the accompanying materials
//  * are made available under the terms of the GNU Lesser General Public License
//  * (LGPL) which accompanies this distribution, and is available at
//  * http://www.gnu.org/licenses/lgpl.html
//  *
//  *  Filename:	ServiceBuilder.cs
//  *  Date:		24/02/2014
//  *  Author:   	Denis Korkhov
//  *
//  */

#endregion

using System;
using System.Linq;
using Cortoxa.IoC.Base;
using Cortoxa.IoC.Interception;

namespace Cortoxa.IoC.Service
{
    public class ServiceBuilder : IServiceBuilder
    {
        private readonly ServiceContext context = new ServiceContext();
        private readonly IServiceInterception interceptor;


        public ServiceBuilder(params Type[] typeFor)
        {
            context.For.AddRange(typeFor);
            interceptor = new ServiceInterception(this);
        }

        public virtual ServiceContext Context
        {
            get { return context; }
        }

        public IServiceDependency Depend { get; private set; }

        public virtual IServiceBuilder To<T>()
        {
            return To(typeof (T));
        }

        public virtual IServiceBuilder To(Type type)
        {
            context.To = type;
            return this;
        }

        public virtual IServiceBuilder ToSelf()
        {
            return To(context.For.First());
        }

        public virtual IServiceBuilder Name(string name)
        {
            context.Name = name;
            return this;
        }

        public IServiceBuilder LifeTime(LifeTime lifeTime)
        {
            context.Lifetime = lifeTime;
            return this;
        }

        public IServiceBuilder InterceptMethod(MethodInteception methodInteceptor)
        {
            context.Interceptors.Add(methodInteceptor);
            return this;
        }

        public IServiceBuilder DependOn(Type type, string dependencyName)
        {
            context.Dependencies.Add(type, dependencyName);
            return this;
        }

        public IServiceInterception Intercept
        {
            get { return interceptor; }
        }

        public static ServiceBuilder For<T>()
        {
            return For(typeof (T));
        }

        public static ServiceBuilder For<T, T2>()
        {
            return For(typeof(T), typeof(T2));
        }

        public static ServiceBuilder For<T, T2, T3>()
        {
            return For(typeof(T), typeof(T2), typeof(T3));
        }

        public static ServiceBuilder For<T, T2, T3, T4>()
        {
            return For(typeof(T), typeof(T2), typeof(T3), typeof(T4));
        }

        public static ServiceBuilder For(params Type[] typeFor)
        {
            return new ServiceBuilder(typeFor);
        }
    }
}
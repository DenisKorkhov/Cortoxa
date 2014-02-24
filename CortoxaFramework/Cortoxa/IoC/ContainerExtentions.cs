#region Copyright © 2014 Denis Korkhov, Oxagile (http://www.oxagile.com/)
// /*
//  * All rights reserved. This program and the accompanying materials
//  * are made available under the terms of the GNU Lesser General Public License
//  * (LGPL) version 2.1 which accompanies this distribution, and is available at
//  * http://www.gnu.org/licenses/lgpl-2.1.html
//  *
//  *  Filename:	ContainerExtentions.cs
//  *  Date:		05/02/2014
//  *  Author:   	Denis Korkhov
//  *
//  */
#endregion
using System;
using System.Linq;
using System.Reflection;
using Cortoxa.Common.Fluent;
using Cortoxa.IoC.Attributes;

namespace Cortoxa.IoC
{
    public static class ContainerExtentions
    {
        public static IToolContainer InstallNative<T>(this IToolContainer container, Action<T> action)
        {
            action(container.GetContainer<T>());
            return container;
        }

//        public static IToolContainer InstallData<T>(this IToolContainer container, Action<T> action) where T : DataAccess, new ()
//        {
////            container.Register(r => r.Service<T>().ToSelf().With(container));
////            var builder = container.Resolve<T>();
//            var builder = (T)Activator.CreateInstance(typeof(T), container);
//            action(builder);
//            builder.Build();
//            return container;
//        }

        public static IToolContainer InstallInjections(this IToolContainer container, Assembly assembly = null)
        {
            if (assembly == null)
            {
                assembly =  Assembly.GetCallingAssembly();
            }
            
            var attributeType = typeof (InjectAttribte);
            var types = assembly.GetTypes().Where(t => Attribute.IsDefined(t, attributeType)).ToArray();
            foreach (var type in types)
            {
                var attribute = type.GetCustomAttributes(attributeType).First() as InjectAttribte;
                if (attribute != null)
                {
                    var intefaces = type.GetInterfaces();
                    Type injectionType = type;
                    if (injectionType.IsClass)
                    {
                        if (intefaces.Any())
                        {
                            var serviceType = intefaces.FirstOrDefault();
                            container.Register(r => r.For(serviceType).To(injectionType).LifeTime(attribute.LifeTime));
                        }
                    }

                    if (injectionType.IsInterface)
                    {
                        container.Register(r => r.For(injectionType).ToSelf().LifeTime(attribute.LifeTime));
                    }
                }
            }
            return container;
        }
    }
}
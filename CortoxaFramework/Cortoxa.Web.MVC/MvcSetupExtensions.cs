#region Copyright © 2014 Denis Korkhov, Oxagile (http://www.oxagile.com/)
// /*
//  * All rights reserved. This program and the accompanying materials
//  * are made available under the terms of the GNU Lesser General Public License
//  * (LGPL) version 2.1 which accompanies this distribution, and is available at
//  * http://www.gnu.org/licenses/lgpl-2.1.html
//  *
//  *  Filename:	MvcSetupExtensions.cs
//  *  Date:		17/02/2014
//  *  Author:   	Denis Korkhov
//  *
//  */
#endregion
using System;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using Cortoxa.Common;
using Cortoxa.Configuration;
using Cortoxa.Container;
using Cortoxa.Container.Component;
using Cortoxa.Container.Extentions;
using Cortoxa.Container.Life;
using Cortoxa.Container.Registrator;
using Cortoxa.Web.MVC.Container;
using Cortoxa.Web.MVC.Controllers;
using Cortoxa.Web.MVC.Factories;

namespace Cortoxa.Web.MVC
{
    public static class MvcSetupExtensions
    {
        public static IToolContainer InstallControllerFactory(this IToolContainer container)
        {
            var currentFactory = ControllerBuilder.Current.GetControllerFactory();
            if (currentFactory == null || currentFactory.GetType() != typeof(ControllerFactory))
            {
                ControllerBuilder.Current.SetControllerFactory(new ControllerFactory(container));
            }
            return container;
        }

//        public static IRegistration Controllers(this IRegistration registration, Type controllerType, LifeTime lifeTime = LifeTime.PerWebRequest, params Assembly[] assemblies)
//        {
//            var configurator = new ComponentConfigurator<ControllersContext>(registration);
//            configurator.Register((r, c) =>
//            {
//                if (controllerType == null)
//                {
//                    controllerType = typeof(Controller);
//                }
//                
//                if (assemblies == null || assemblies.Length == 0)
//                {
//                    assemblies = new[]
//                    {
//                        Assembly.GetCallingAssembly()
//                    };
//                }
//                r.Type().Assemblies(assemblies).Where(t => t.BasedOn(controllerType));
//            });
//
//            configurator.Configure(c => c.LifeTime = lifeTime);
//            configurator.Configure(c => c.ControllerType = controllerType);
//            configurator.Configure(c => c.Assemblies = assemblies);
//            configurator.Build();
//            return registration;
//        }

//        public static void Controllers(this IRegistration registrator, Assembly assembly, LifeTime lifeTime = LifeTime.Transient)
//        {
//            registrator.Controllers(typeof(Controller), LifeTime.PerWebRequest, assembly);
//        }
//
//        public static void Controllers(this IRegistration registrator, LifeTime lifeTime = LifeTime.Transient)
//        {
//            registrator.Controllers(typeof(Controller), LifeTime.PerWebRequest, null);
//        }

        public static IComponentConfigurator<ControllersContext> Controllers<T>(this IRegistration registrator) where T : class
        {
            var configurator = new ComponentConfigurator<ControllersContext>(registrator);
            configurator.Register((r, c) => r.Type().Assemblies(c.Assemblies.ToArray()).Where(x => x.BasedOn(c.ControllerType)).LifeTime(c.LifeTime));
            configurator.Configure(c=>c.ControllerType = typeof(T));
            return configurator;
        }
    }
}
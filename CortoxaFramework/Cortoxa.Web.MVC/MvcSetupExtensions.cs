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
using System.Reflection;
using System.Web.Mvc;
using Cortoxa.Common;
using Cortoxa.Container;
using Cortoxa.Container.Component;
using Cortoxa.Container.Life;
using Cortoxa.Container.Registrator;
using Cortoxa.Web.MVC.Controllers;
using Cortoxa.Web.MVC.Factories;

namespace Cortoxa.Web.MVC
{
    public static class MvcSetupExtensions
    {
        public static IToolContainer SetupControllerFactory(this IToolContainer container)
        {
            var currentFactory = ControllerBuilder.Current.GetControllerFactory();
            if (currentFactory == null || currentFactory.GetType() != typeof(ControllerFactory))
            {
                ControllerBuilder.Current.SetControllerFactory(new ControllerFactory(container.Resolver));
            }
            return container;
        }

        public static IRegistration Controllers(this IRegistration registration, Type controllerType, LifeTime lifeTime = LifeTime.PerWebRequest, params Assembly[] assemblies)
        {
            var configurator = new ComponentConfigurator<ControllersContext>(registration);
            configurator.Configure(c => c.LifeTime = lifeTime);
            configurator.Configure(c => c.ControllerType = controllerType);
            configurator.Configure(c => c.Assemblies = assemblies);
            configurator.ConfigureBuild(c =>
            {
                if (controllerType == null)
                {
                    controllerType = typeof(Controller);
                }

                var aaa = Assembly.GetCallingAssembly();
                var aaa2 = Assembly.GetEntryAssembly();
                var aaa3 = Assembly.GetExecutingAssembly();

                if (assemblies == null || assemblies.Length == 0)
                {
                    assemblies = new[]
                    {
                        Assembly.GetCallingAssembly()
                    };
                }
                registration.Type(assemblies).Where(t => t.BasedOn(controllerType));
            });
            configurator.Build();
            return registration;

        }

        public static void Controllers(this IRegistration registrator, Assembly assembly, LifeTime lifeTime = LifeTime.Transient)
        {
            registrator.Controllers(typeof(Controller), LifeTime.PerWebRequest, assembly);
        }

        public static void Controllers(this IRegistration registrator, LifeTime lifeTime = LifeTime.Transient)
        {
            registrator.Controllers(typeof(Controller), LifeTime.PerWebRequest, null);
        }
    }
}
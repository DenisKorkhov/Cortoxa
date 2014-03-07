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
using Cortoxa.IoC;
using Cortoxa.IoC.Base;
using Cortoxa.Web.MVC.Factories;

namespace Cortoxa.Web.MVC
{
    public static class MvcSetupExtensions
    {
            public static IToolContainer InstallControllers(this IToolContainer container, LifeTime lifeTime = LifeTime.Transient)
            {
                return container.InstallControllers(typeof(Controller), lifeTime, Assembly.GetCallingAssembly());
            }

            public static IToolContainer InstallControllers(this IToolContainer container, Type controllerType, LifeTime lifeTime = LifeTime.PerWebRequest, params Assembly[] assemblies)
            {
                var currentFactory = ControllerBuilder.Current.GetControllerFactory();
                if (currentFactory == null || currentFactory.GetType() != typeof(ControllerFactory))
                {
                    ControllerBuilder.Current.SetControllerFactory(new ControllerFactory(container));
                }
        
                if (controllerType == null)
                {
                    controllerType = typeof(Controller);
                }
        
                if (assemblies == null || assemblies.Length == 0)
                {
                    assemblies = new[]
                    {
                        Assembly.GetCallingAssembly()
                    };
                }

//                container.Register(r => r.From(assemblies).BasedOn(controllerType).LifeTime(lifeTime));
                return container;
            }
    }
}
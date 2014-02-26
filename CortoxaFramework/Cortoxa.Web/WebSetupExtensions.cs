#region Copyright © 2014 Denis Korkhov, Oxagile (http://www.oxagile.com/)
// /*
//  * All rights reserved. This program and the accompanying materials
//  * are made available under the terms of the GNU Lesser General Public License
//  * (LGPL) version 2.1 which accompanies this distribution, and is available at
//  * http://www.gnu.org/licenses/lgpl-2.1.html
//  *
//  *  Filename:	WebSetupExtensions.cs
//  *  Date:		17/02/2014
//  *  Author:   	Denis Korkhov
//  *
//  */
#endregion
using System;
using System.Reflection;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using Cortoxa.IoC;
using Cortoxa.IoC.Base;
using Cortoxa.Web.Factories;

namespace Cortoxa.Web
{
    public static class WebSetupExtensions
    {
        public static IToolContainer InstallApiControllers(this IToolContainer container, LifeTime lifeTime = LifeTime.Transient)
        {
            return container.InstallApiControllers(typeof(ApiController), lifeTime, Assembly.GetCallingAssembly());
        }

        public static IToolContainer InstallApiControllers(this IToolContainer container, Type controllerType, LifeTime lifeTime = LifeTime.PerWebRequest, params Assembly[] assemblies)
        {
            GlobalConfiguration.Configuration.Services.Replace(typeof(IHttpControllerActivator),new WebCompositionRoot(container.Resolve));

            if (controllerType == null)
            {
                controllerType = typeof(ApiController);
            }
            
            if (assemblies == null || assemblies.Length == 0)
            {
                assemblies = new[]
                {
                    Assembly.GetCallingAssembly()
                };
            }
            
//            container.Register(r => r.From(assemblies).BasedOn(controllerType).LifeTime(lifeTime));
            return container;
        }
    }
}
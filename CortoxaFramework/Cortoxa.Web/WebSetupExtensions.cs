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
using Cortoxa.Container;
using Cortoxa.Container.Life;
using Cortoxa.Web.Factories;

namespace Cortoxa.Web
{
    public static class WebSetupExtensions
    {
        public static IToolContainer InstallApiControllerFactory(this IToolContainer container)
        {
            GlobalConfiguration.Configuration.Services.Replace(typeof(IHttpControllerActivator), new WebCompositionRoot(container));
            return container;
        }
    }
}
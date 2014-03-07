#region Copyright © 2014 Denis Korkhov, Oxagile (http://www.oxagile.com/)
// /*
//  * All rights reserved. This program and the accompanying materials
//  * are made available under the terms of the GNU Lesser General Public License
//  * (LGPL) version 2.1 which accompanies this distribution, and is available at
//  * http://www.gnu.org/licenses/lgpl-2.1.html
//  *
//  *  Filename:	CortoxaExtentions.cs
//  *  Date:		18/02/2014
//  *  Author:   	Denis Korkhov
//  *
//  */
#endregion
using System;
using Cortoxa.IoC;
using Owin;

namespace Cortoxa.Owin
{
    public static class CortoxaExtentions
    {
        private const string CortoxaContainerName = "cortoxa_root";

        public static IToolContainer UseContainer(this IAppBuilder appBuilder, Func<IToolContainer, IToolContainer> setupAction)
        {
            var container = setupAction(null);
            appBuilder.Properties[CortoxaContainerName] = container;
            return container;
        }

        public static IToolContainer Container(this IAppBuilder appBuilder)
        {
            return appBuilder.Properties[CortoxaContainerName] as IToolContainer;
        }
    }
}
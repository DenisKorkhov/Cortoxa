#region Copyright © 2014 Denis Korkhov, Oxagile (http://www.oxagile.com/)
// /*
//  * All rights reserved. This program and the accompanying materials
//  * are made available under the terms of the GNU Lesser General Public License
//  * (LGPL) version 2.1 which accompanies this distribution, and is available at
//  * http://www.gnu.org/licenses/lgpl-2.1.html
//  *
//  *  Filename:	IocSetup.cs
//  *  Date:		05/02/2014
//  *  Author:   	Denis Korkhov
//  *
//  */
#endregion

using System;
using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Castle.Windsor;
using Cortoxa.Configuration;
using Cortoxa.Container;
using Cortoxa.Tool;
using Cortoxa.Windsor.Tool;

namespace Cortoxa.Windsor
{
    public static class IocSetup
    {
        public static void UseWindsor(this IConfigurator<IToolContainer> setupAction)
        {
            var container = new WindsorContainer();
            container.Kernel.Resolver.AddSubResolver(new ArrayResolver(container.Kernel));
            setupAction.UseWindsor(container);
        }

        public static void UseWindsor(this IConfigurator<IToolContainer> setupAction, IWindsorContainer instance)
        {
            var toolContainer = new ToolContainer(new WindsorToolContainer(instance));
            setupAction.Setup(c => c(toolContainer));
        }
    }
}
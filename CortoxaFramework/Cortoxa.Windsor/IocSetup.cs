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

using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Castle.Windsor;
using Cortoxa.Container;
using Cortoxa.Container.Common;
using Cortoxa.Windsor.Tool;

namespace Cortoxa.Windsor
{
    public static class IocSetup
    {
        public static void UseWindsor(this ISetupConfigurator<IToolContainer> setup)
        {
            var container = new WindsorContainer();
            container.Kernel.Resolver.AddSubResolver(new ArrayResolver(container.Kernel));
            UseWindsor(setup, container);
        }

        public static void UseWindsor(this ISetupConfigurator<IToolContainer> setup, IWindsorContainer instance)
        {
            setup.Create(()=>new WindsorToolContainer(instance));
        }
    }
}
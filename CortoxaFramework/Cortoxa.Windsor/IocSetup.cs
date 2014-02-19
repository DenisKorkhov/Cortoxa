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
using Cortoxa.IoC;

namespace Cortoxa.Windsor
{
    public static class IocSetup
    {
        public static IToolContainer UseWindsor(this IToolSetup<IToolContainer> setup)
        {
            var container = new WindsorContainer();
            container.Kernel.Resolver.AddSubResolver(new ArrayResolver(container.Kernel));
            return UseWindsor(setup, container);
        }

        public static IToolContainer UseWindsor(this IToolSetup<IToolContainer> setup, IWindsorContainer instance)
        {
            return new WindsorToolContainer(instance);
        }
    }
}
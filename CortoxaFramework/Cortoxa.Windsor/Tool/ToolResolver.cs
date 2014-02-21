#region Copyright © 2014 Denis Korkhov, Oxagile (http://www.oxagile.com/)
// /*
//  * All rights reserved. This program and the accompanying materials
//  * are made available under the terms of the GNU Lesser General Public License
//  * (LGPL) which accompanies this distribution, and is available at
//  * http://www.gnu.org/licenses/lgpl.html
//  *
//  *  Filename:	ToolResolver.cs
//  *  Date:		21/02/2014
//  *  Author:   	Denis Korkhov
//  *
//  */
#endregion

using System;
using System.Linq;
using Castle.Windsor;
using Cortoxa.IoC2;

namespace Cortoxa.Windsor.Tool
{
    public class ToolResolver : IToolResolver
    {
        private readonly IWindsorContainer container;

        public ToolResolver(IWindsorContainer container)
        {
            this.container = container;
        }

        public T One<T>(object arguments = null)
        {
            return arguments != null ? container.Resolve<T>(arguments) : container.Resolve<T>();
        }

        public object One(Type type, object arguments = null)
        {
            return arguments != null ? container.Resolve(type, arguments) : container.Resolve(type);
        }

        public T One<T>(Type type, object arguments = null)
        {
            var result = arguments != null ? (T) container.Resolve(type, arguments) : container.Resolve(type);
            return (T)result;
        }

        public T One<T>(string key, object arguments = null)
        {
            return arguments != null ? container.Resolve<T>(key, arguments) : container.Resolve<T>(key);
        }

        public T[] All<T>(object arguments = null)
        {
            return arguments != null ? container.ResolveAll<T>(arguments) : container.ResolveAll<T>();
        }

        public object[] All(Type type, object arguments = null)
        {
            var result = arguments != null ? container.ResolveAll(type, arguments) : container.ResolveAll(type);
            return result.Cast<object>().ToArray();
        }

        public T[] All<T>(Type type, object arguments = null)
        {
            var result = arguments != null ? container.ResolveAll(type, arguments) : container.ResolveAll(type);
            return result.Cast<T>().ToArray();
        }
    }
}
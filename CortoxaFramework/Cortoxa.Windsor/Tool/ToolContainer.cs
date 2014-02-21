#region Copyright © 2014 Denis Korkhov, Oxagile (http://www.oxagile.com/)
// /*
//  * All rights reserved. This program and the accompanying materials
//  * are made available under the terms of the GNU Lesser General Public License
//  * (LGPL) which accompanies this distribution, and is available at
//  * http://www.gnu.org/licenses/lgpl.html
//  *
//  *  Filename:	ToolContainer.cs
//  *  Date:		21/02/2014
//  *  Author:   	Denis Korkhov
//  *
//  */
#endregion

using Castle.Windsor;
using Cortoxa.IoC2;
using Cortoxa.Windsor.Tool;

namespace Cortoxa.Windsor
{
    public class ToolContainer : IToolContainer2
    {
        private readonly IWindsorContainer container;

        public ToolContainer(IWindsorContainer container)
        {
            this.container = container;
            Register = new ToolRegistrator(this);
            Resolve = new ToolResolver(container);
        }

        public IToolRegistrator Register { get; private set; }

        public IToolResolver Resolve { get; private set; }

        public T Container<T>()
        {
            return (T) container;
        }
    }
}
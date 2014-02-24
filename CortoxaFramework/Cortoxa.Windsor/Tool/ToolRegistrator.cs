#region Copyright © 2014 Denis Korkhov, Oxagile (http://www.oxagile.com/)
// /*
//  * All rights reserved. This program and the accompanying materials
//  * are made available under the terms of the GNU Lesser General Public License
//  * (LGPL) which accompanies this distribution, and is available at
//  * http://www.gnu.org/licenses/lgpl.html
//  *
//  *  Filename:	ToolRegistrator.cs
//  *  Date:		21/02/2014
//  *  Author:   	Denis Korkhov
//  *
//  */
#endregion

using System;
using Castle.Windsor;
using Cortoxa.IoC2;
using Cortoxa.IoC2.Base;
using Cortoxa.IoC2.Service;
using Cortoxa.Windsor.Service;

namespace Cortoxa.Windsor
{
    public class ToolRegistrator : IToolRegistrator
    {
        private readonly IToolContainer2 container;

        public ToolRegistrator(IToolContainer2 container)
        {
            this.container = container;
        }

        public IToolRegistrator Service<T>(Action<IServiceBuilder> serviceAction)
        {
            return this.Service(typeof (T), serviceAction);
        }

        public IToolRegistrator Service(Type type, Action<IServiceBuilder> serviceAction)
        {
//            var service = ServiceBuilder.For(type, container);
//            serviceAction(service);
//            service.Done();
            return this;
        }

//        public IToolContainer2 Component(IToolComponent component)
//        {
//            throw new NotImplementedException();
//        }
    }
}
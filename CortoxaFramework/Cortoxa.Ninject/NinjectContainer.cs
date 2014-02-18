#region Copyright © 2014 Denis Korkhov, Oxagile (http://www.oxagile.com/)
// /*
//  * All rights reserved. This program and the accompanying materials
//  * are made available under the terms of the GNU Lesser General Public License
//  * (LGPL) version 2.1 which accompanies this distribution, and is available at
//  * http://www.gnu.org/licenses/lgpl-2.1.html
//  *
//  *  Filename:	NinjectContainer.cs
//  *  Date:		04/02/2014
//  *  Author:   	Denis Korkhov
//  *
//  */
#endregion
using System;
using Cortoxa.IoC;
using Cortoxa.IoC.Registration;
using Ninject;

namespace Cortoxa.Ninject
{
    public class NinjectContainer : IToolContainer
    {
        private readonly IKernel container;

        public NinjectContainer(IKernel container)
        {
            this.container = container;
        }

        public T GetContainer<T>()
        {
            throw new NotImplementedException();
        }

        public IToolContainer Register(params IToolRegistration[] registration)
        {
            throw new NotImplementedException();
        }

        public IToolContainer Register(Action<IToolRegistration> registration)
        {
            throw new NotImplementedException();
        }

        public IToolContainer Register<T>(Action<T> registration)
        {
            var container = GetContainer<T>();
            registration(container);
            return this;
        }

        public T Resolve<T>(object arguments = null)
        {
            throw new NotImplementedException();
        }

        public object Resolve(Type type, object arguments = null)
        {
            throw new NotImplementedException();
        }

        public T Resolve<T>(Type type, object arguments = null)
        {
            throw new NotImplementedException();
        }

        public void Release(object instance)
        {
            throw new NotImplementedException();
        }

        public void Release(Type type)
        {
            throw new NotImplementedException();
        }

        public void Release<T>()
        {
            throw new NotImplementedException();
        }
    }
}
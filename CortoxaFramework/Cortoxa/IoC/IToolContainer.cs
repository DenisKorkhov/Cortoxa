#region Copyright © 2014 Denis Korkhov, Oxagile (http://www.oxagile.com/)
// /*
//  * All rights reserved. This program and the accompanying materials
//  * are made available under the terms of the GNU Lesser General Public License
//  * (LGPL) version 2.1 which accompanies this distribution, and is available at
//  * http://www.gnu.org/licenses/lgpl-2.1.html
//  *
//  *  Filename:	IToolContainer.cs
//  *  Date:		05/02/2014
//  *  Author:   	Denis Korkhov
//  *
//  */
#endregion
using System;
using Cortoxa.IoC.Registration;

namespace Cortoxa.IoC
{
    public interface IToolContainer
    {
        T GetContainer<T>();

        IToolContainer Register(params IToolRegistration[] registration);

        IToolContainer Register(Action<IToolRegistration> registration);

        IToolContainer Register<T>(Action<T> registration);

        T Resolve<T>(object arguments = null);

        object Resolve(Type controllerType, object arguments = null);

        T Resolve<T>(Type controllerType, object arguments = null);

        T Resolve<T>(string key, object arguments = null);

        T[] ResolveAll<T>(object arguments = null);

        object[] ResolveAll(Type controllerType, object arguments = null);

        T[] ResolveAll<T>(Type controllerType, object arguments = null);

        T[] ResolveAll<T>(string key, object arguments = null);

        void Release(object instance);


    }
}
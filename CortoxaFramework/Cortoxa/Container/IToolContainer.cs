#region Copyright © 2014 Denis Korkhov, Oxagile (http://www.oxagile.com/)
// 
// // /*
// //  * All rights reserved. This program and the accompanying materials
// //  * are made available under the terms of the GNU Lesser General Public License
// //  * (LGPL) version 2.1 which accompanies this distribution, and is available at
// //  * http://www.gnu.org/licenses/lgpl-2.1.html
// //  *
// //  *  Filename:	IToolContainer.cs
// //  *  Date:		11/03/2014
// //  *  Author:   	Denis Korkhov
// //  *
// //  */
#endregion

using System;
using Cortoxa.Container.Registrator;

namespace Cortoxa.Container
{
    public interface IToolContainer
    {
        IToolContainer Register(Action<IRegistration> registrator);

        IResolver Resolver { get; }

//        T Resolve<T>(object arguments = null);
//
//        object Resolve(Type type, object arguments = null);
//
//        T Resolve<T>(Type type, object arguments = null);
//
//        T Resolve<T>(string key, object arguments = null);
//
//        T[] ResolveAll<T>(object arguments = null);
//
//        object[] ResolveAll(Type type, object arguments = null);
//
//        T[] ResolveAll<T>(Type type, object arguments = null);
//
//        void Release(Type type);
//
//        void Release(object instance);
    }
}
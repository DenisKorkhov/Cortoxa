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
using Cortoxa.Container.Component;
using Cortoxa.Container.Registrator;

namespace Cortoxa.Container
{
    public interface IToolContainer
    {
        IToolContainer Register(Action<IRegistration> registrator);

        IToolContainer RegisterNative<T>(Action<T> registrator);

        IToolContainer Register<T>(Func<IRegistration, IComponentConfigurator<T>> regAction) where T : class;

        IResolver Resolver { get; }

        void Release(object instance);

        void TraceDependencies();

    }
}
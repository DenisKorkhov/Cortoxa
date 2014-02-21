#region Copyright © 2014 Denis Korkhov, Oxagile (http://www.oxagile.com/)
// /*
//  * All rights reserved. This program and the accompanying materials
//  * are made available under the terms of the GNU Lesser General Public License
//  * (LGPL) which accompanies this distribution, and is available at
//  * http://www.gnu.org/licenses/lgpl.html
//  *
//  *  Filename:	IServiceRegistration.cs
//  *  Date:		21/02/2014
//  *  Author:   	Denis Korkhov
//  *
//  */
#endregion

using System;
using Cortoxa.IoC2.Fluent;

namespace Cortoxa.IoC2
{
    public interface IServiceRegistration//: ISubBuilder<IToolContainer2>
    {
        IServiceInterception Intercept { get; }

        IServiceDependency Depend { get; }

        IServiceRegistration To<T>();

        IServiceRegistration To(Type type);

        IServiceRegistration ToSelf();

        IServiceRegistration Name(string name);
    }
}
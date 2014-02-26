#region Copyright © 2014 Denis Korkhov, Oxagile (http://www.oxagile.com/)

// /*
//  * All rights reserved. This program and the accompanying materials
//  * are made available under the terms of the GNU Lesser General Public License
//  * (LGPL) which accompanies this distribution, and is available at
//  * http://www.gnu.org/licenses/lgpl.html
//  *
//  *  Filename:	IServiceBuilder.cs
//  *  Date:		21/02/2014
//  *  Author:   	Denis Korkhov
//  *
//  */

#endregion

using System;
using Cortoxa.IoC.Interception;

namespace Cortoxa.IoC.Base
{
    public interface IServiceBuilder // : IServiceBuilderName
    {
        IServiceInterception Intercept { get; }

//        IServiceDependency Depend { get; }

        IServiceBuilder To<T>();

        IServiceBuilder To(Type type);

        IServiceBuilder ToSelf();

        IServiceBuilder Name(string name);

        IServiceBuilder LifeTime(LifeTime lifeTime);

        IServiceBuilder InterceptMethod(MethodInteception methodInteceptor);

        IServiceBuilder DependOn(Type type, string dependencyName);
    }
}
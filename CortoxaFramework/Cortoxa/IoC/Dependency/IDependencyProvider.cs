#region Copyright © 2014 Denis Korkhov, Oxagile (http://www.oxagile.com/)
// /*
//  * All rights reserved. This program and the accompanying materials
//  * are made available under the terms of the GNU Lesser General Public License
//  * (LGPL) which accompanies this distribution, and is available at
//  * http://www.gnu.org/licenses/lgpl.html
//  *
//  *  Filename:	IDependencyProvider.cs
//  *  Date:		19/02/2014
//  *  Author:   	Denis Korkhov
//  *
//  */
#endregion

using System;

namespace Cortoxa.IoC.Dependency
{
    public interface IDependencyProvider
    {
        string DependencyName { get; }

        void RegisterDependency(Type serviceType, string dependencyName);
    }
}
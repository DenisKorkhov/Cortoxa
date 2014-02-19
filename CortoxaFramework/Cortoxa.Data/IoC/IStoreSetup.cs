#region Copyright © 2014 Denis Korkhov, Oxagile (http://www.oxagile.com/)
// /*
//  * All rights reserved. This program and the accompanying materials
//  * are made available under the terms of the GNU Lesser General Public License
//  * (LGPL) which accompanies this distribution, and is available at
//  * http://www.gnu.org/licenses/lgpl.html
//  *
//  *  Filename:	IStoreSetup.cs
//  *  Date:		19/02/2014
//  *  Author:   	Denis Korkhov
//  *
//  */
#endregion

using System;
using Cortoxa.Data.Context;
using Cortoxa.IoC.Attributes;
using Cortoxa.IoC.Common;

namespace Cortoxa.Data.IoC
{
    public interface IStoreSetup : IRegistrationStratagy
    {
        IStoreSetup WithSession<T>(ToolkitLifeTime lifeTime = ToolkitLifeTime.Transient) where T : IDbSession;

        IStoreSetup WithRepository<T>(ToolkitLifeTime lifeTime = ToolkitLifeTime.Transient);

        IStoreSetup WithRepository(Type type, ToolkitLifeTime lifeTime = ToolkitLifeTime.Transient);
    }
}
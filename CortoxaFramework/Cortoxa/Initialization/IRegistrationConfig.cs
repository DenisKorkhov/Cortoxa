#region Copyright © 2014 Denis Korkhov, Oxagile (http://www.oxagile.com/)
// /*
//  * All rights reserved. This program and the accompanying materials
//  * are made available under the terms of the GNU Lesser General Public License
//  * (LGPL) version 2.1 which accompanies this distribution, and is available at
//  * http://www.gnu.org/licenses/lgpl-2.1.html
//  *
//  *  Filename:	IRegistrationConfig.cs
//  *  Date:		17/02/2014
//  *  Author:   	Denis Korkhov
//  *
//  */
#endregion
using System;
using Cortoxa.IoC.Common;

namespace Cortoxa.Initialization
{
    public interface IRegistrationConfig : IRegistrationStratagy
    {
        void Configure(IRegistrationStratagy stratagy);

        void Configure<T>(Action<T> configurationAction) where T : IRegistrationStratagy;

        void Configure<T>(Func<T, T> configurationAction) where T : IRegistrationStratagy;
    }
}
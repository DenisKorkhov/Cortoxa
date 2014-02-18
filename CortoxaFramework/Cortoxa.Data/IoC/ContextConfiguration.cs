#region Copyright © 2014 Denis Korkhov, Oxagile (http://www.oxagile.com/)
// /*
//  * All rights reserved. This program and the accompanying materials
//  * are made available under the terms of the GNU Lesser General Public License
//  * (LGPL) version 2.1 which accompanies this distribution, and is available at
//  * http://www.gnu.org/licenses/lgpl-2.1.html
//  *
//  *  Filename:	ContextConfiguration.cs
//  *  Date:		17/02/2014
//  *  Author:   	Denis Korkhov
//  *
//  */
#endregion
using System;
using Cortoxa.Data.Context;
using Cortoxa.IoC;
using Cortoxa.IoC.Attributes;
using Cortoxa.IoC.Common;

namespace Cortoxa.Data.IoC
{
    public class ContextConfiguration : IRegistrationStratagy
    {
        public ToolkitLifeTime LifeTime { get; set; }

        public Type Type { get; set; }

        public void Register(IToolContainer container)
        {
            container.Register(r => r.For<IDbContext>().To(Type).LifeTime(LifeTime));
        }
    }
}
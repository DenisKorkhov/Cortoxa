#region Copyright © 2014 Denis Korkhov, Oxagile (http://www.oxagile.com/)
// /*
//  * All rights reserved. This program and the accompanying materials
//  * are made available under the terms of the GNU Lesser General Public License
//  * (LGPL) which accompanies this distribution, and is available at
//  * http://www.gnu.org/licenses/lgpl.html
//  *
//  *  Filename:	RepositoryConfiguration.cs
//  *  Date:		17/02/2014
//  *  Author:   	Denis Korkhov
//  *
//  */
#endregion
using System;
using Cortoxa.Data.Repository;
using Cortoxa.IoC;
using Cortoxa.IoC.Base;

namespace Cortoxa.Data.IoC
{
    public class RepositoryConfiguration : IRegistrationStratagy
    {
        public RepositoryConfiguration(Type type, LifeTime lifeTime)
        {
            LifeTime = lifeTime;
            Type = type;
        }

        public LifeTime LifeTime { get; set; }

        public Type Type { get; set; }

        public void Register(IToolRegistrator container)
        {
//            container.Register(r => r.For(typeof(IStore<>)).To(Type).LifeTime(LifeTime));
        }
    }
}
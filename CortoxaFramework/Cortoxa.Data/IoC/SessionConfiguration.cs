#region Copyright © 2014 Denis Korkhov, Oxagile (http://www.oxagile.com/)
// /*
//  * All rights reserved. This program and the accompanying materials
//  * are made available under the terms of the GNU Lesser General Public License
//  * (LGPL) which accompanies this distribution, and is available at
//  * http://www.gnu.org/licenses/lgpl.html
//  *
//  *  Filename:	SessionConfiguration.cs
//  *  Date:		19/02/2014
//  *  Author:   	Denis Korkhov
//  *
//  */
#endregion

using System;
using Cortoxa.Data.Context;
using Cortoxa.IoC;
using Cortoxa.IoC.Base;

namespace Cortoxa.Data.IoC
{
    public class SessionConfiguration : IRegistrationStratagy
    {
        public Type Type { get; set; }

        public LifeTime LifeTime { get; set; }

        public SessionConfiguration(Type type, LifeTime lifeTime)
        {
            Type = type;
            LifeTime = lifeTime;
        }

        public void Register(IToolRegistrator container)
        {
//            var sessionName = string.Format("dbsession.{0}", configurationScope ?? string.Empty);
//            container.Register(r => r.For<IDbSession>().To(Type).LifeTime(LifeTime));
        }
    }
}
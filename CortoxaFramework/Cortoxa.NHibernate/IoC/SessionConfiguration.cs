﻿#region Copyright © 2014 Denis Korkhov, Oxagile (http://www.oxagile.com/)
// /*
//  * All rights reserved. This program and the accompanying materials
//  * are made available under the terms of the GNU Lesser General Public License
//  * (LGPL) version 2.1 which accompanies this distribution, and is available at
//  * http://www.gnu.org/licenses/lgpl-2.1.html
//  *
//  *  Filename:	SessionConfiguration.cs
//  *  Date:		17/02/2014
//  *  Author:   	Denis Korkhov
//  *
//  */
#endregion
using System;
using Cortoxa.Data.Schema;
using Cortoxa.IoC;
using Cortoxa.IoC.Attributes;
using Cortoxa.IoC.Common;
using Cortoxa.IoC.Registration.Extentions;
using NHibernate;

namespace Cortoxa.NHibernate.IoC
{
    public class SessionConfiguration : IRegistrationStratagy
    {
        public ToolkitLifeTime LifeTime { get; set; }

        public Func<IModelBuilder, ISessionFactory> SessionFactory { get; set; }

        public void Register(IToolContainer container)
        {
            container.Register(r => r.For<ISessionFactory>().ToFactory(x => SessionFactory(null)).LifeTime(ToolkitLifeTime.Singleton));
            container.Register(r => r.For<ISession>().ToFactory(x =>
            {
                var c = container;
                var factory = c.Resolve<ISessionFactory>();
                return factory.OpenSession();
            }).LifeTime(LifeTime));
        }
    }
}

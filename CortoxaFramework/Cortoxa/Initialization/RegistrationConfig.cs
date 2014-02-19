#region Copyright © 2014 Denis Korkhov, Oxagile (http://www.oxagile.com/)
// /*
//  * All rights reserved. This program and the accompanying materials
//  * are made available under the terms of the GNU Lesser General Public License
//  * (LGPL) version 2.1 which accompanies this distribution, and is available at
//  * http://www.gnu.org/licenses/lgpl-2.1.html
//  *
//  *  Filename:	RegistrationConfig.cs
//  *  Date:		17/02/2014
//  *  Author:   	Denis Korkhov
//  *
//  */
#endregion
using System;
using System.Collections.Generic;
using Cortoxa.IoC;
using Cortoxa.IoC.Common;

namespace Cortoxa.Initialization
{
    public abstract class RegistrationConfig : IRegistrationConfig
    {
        private readonly IDictionary<Type, IRegistrationStratagy> stratagies = new Dictionary<Type, IRegistrationStratagy>();

        public string ConfigurationScope { get; private set; }

        protected RegistrationConfig()
        {
            ConfigurationScope = null;
        }

        protected RegistrationConfig(string configurationScope)
        {
            ConfigurationScope = configurationScope;
        }

        public string Scope { get; set; }

        public void Register(IToolContainer container)
        {
            foreach (var stratagy in stratagies.Values)
            {
                stratagy.Register(container/*, ConfigurationScope*/);
            }
        }

        public void Configure(IRegistrationStratagy stratagy)
        {
            stratagies[stratagy.GetType()] = stratagy;
        }

        public void Configure<T>(Action<T> configurationAction) where T : IRegistrationStratagy
        {
            configurationAction((T) stratagies[typeof (T)]);
        }

        public void Configure<T>(Func<T, T> configurationAction) where T : IRegistrationStratagy
        {
            var result = configurationAction((T)stratagies[typeof(T)]);
            stratagies[typeof (T)] = result;
        }
    }
}
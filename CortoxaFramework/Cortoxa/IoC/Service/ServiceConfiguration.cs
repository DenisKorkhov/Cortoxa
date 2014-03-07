#region Copyright © 2014 Denis Korkhov, Oxagile (http://www.oxagile.com/)

// /*
//  * All rights reserved. This program and the accompanying materials
//  * are made available under the terms of the GNU Lesser General Public License
//  * (LGPL) which accompanies this distribution, and is available at
//  * http://www.gnu.org/licenses/lgpl.html
//  *
//  *  Filename:	ServiceConfiguration.cs
//  *  Date:		21/02/2014
//  *  Author:   	Denis Korkhov
//  *
//  */

#endregion

using System;
using System.Collections.Generic;
using Cortoxa.IoC.Base;
using Cortoxa.IoC.Common;
using Cortoxa.IoC.Factory;
using Cortoxa.IoC.Interception;

namespace Cortoxa.IoC.Service
{
    public sealed class ServiceConfiguration : IRegistrationContext
    {
        private readonly IDictionary<Type, string> dependencies = new Dictionary<Type, string>();

        private readonly IList<MethodInteception> interceptors = new List<MethodInteception>();

        internal ServiceConfiguration()
        {
        }

        public Type[] For { get; set; }
    
        public Type To { get; set; }

        public Func<FactoryContext, object> ToFactory { get; set; }

        public string Name { get; set; }

        public LifeTime Lifetime { get; set; }

        public IDictionary<Type, string> Dependencies
        {
            get { return dependencies; }
        }

        public IList<MethodInteception> Interceptors
        {
            get { return interceptors; }
        }
    }
}
#region Copyright © 2014 Denis Korkhov, Oxagile (http://www.oxagile.com/)
// /*
//  * All rights reserved. This program and the accompanying materials
//  * are made available under the terms of the GNU Lesser General Public License
//  * (LGPL) version 2.1 which accompanies this distribution, and is available at
//  * http://www.gnu.org/licenses/lgpl-2.1.html
//  *
//  *  Filename:	TypeContext.cs
//  *  Date:		05/02/2014
//  *  Author:   	Denis Korkhov
//  *
//  */
#endregion
using System;
using System.Collections.Generic;
using System.Reflection;
using Cortoxa.IoC.Attributes;
using Cortoxa.IoC.Interception;

namespace Cortoxa.IoC
{
    public class TypeContext
    {
        private readonly IList<Assembly> assemblies = new List<Assembly>();
        private readonly IList<MethodInteception> interceptors = new List<MethodInteception>();
        private readonly IDictionary<Type, string> dependencies = new Dictionary<Type, string>();
        
        public Type For { get; set; }

        public Type BasedOn { get; set; }

        public Type To { get; set; }

        public Func<FactoryContext, object> ToFactory{ get; set; }

        public IDictionary<Type, string> Dependencies { get { return dependencies; } }

        public object Attributies { get; set; }

        public string Name { get; set; }

        public ToolkitLifeTime Lifetime { get; set; }

        public IList<Assembly> Assemblies
        {
            get { return assemblies; }
        }

        public IList<MethodInteception> Interceptors
        {
            get { return interceptors; }
        }

        public string Namespace { get; set; }
    }
}
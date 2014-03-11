#region Copyright © 2014 Denis Korkhov, Oxagile (http://www.oxagile.com/)

// /*
//  * All rights reserved. This program and the accompanying materials
//  * are made available under the terms of the GNU Lesser General Public License
//  * (LGPL) version 2.1 which accompanies this distribution, and is available at
//  * http://www.gnu.org/licenses/lgpl-2.1.html
//  *
//  *  Filename:	InterceptionContext.cs
//  *  Date:		05/02/2014
//  *  Author:   	Denis Korkhov
//  *
//  */

#endregion

using System;
using System.Collections.Generic;
using System.Reflection;

namespace Cortoxa.Container.Services
{
    public class InterceptionContext
    {
        public Type RequestedType { get; set; }

        public Type ResolverType { get; set; }

        public MethodInfo Method { get; set; }

        public object[] Arguments { get; set; }

        public object Result { get; set; }

        public IDictionary<string, object> Metadata { get; set; }

        public Action Procced { get; set; }
    }
}
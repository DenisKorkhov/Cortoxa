#region Copyright © 2014 

// /*
//  * All rights reserved. This program and the accompanying materials
//  * are made available under the terms of the GNU Lesser General Public License
//  * (LGPL) version 2.1 which accompanies this distribution, and is available at
//  * http://www.gnu.org/licenses/lgpl-2.1.html
//  *
//  *  Filename:	FactoryContext.cs
//  *  Date:		05/02/2014
//  *  Author:   	Denis Korkhov
//  *
//  */

#endregion

using System;

namespace Cortoxa.Container.Services
{
    public class FactoryContext
    {
        public Type RequestedType { get; set; }

        public object[] Arguments { get; set; }
    }
}
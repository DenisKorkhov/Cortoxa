#region Copyright © 2014 
// /*
//  * All rights reserved. This program and the accompanying materials
//  * are made available under the terms of the GNU Lesser General Public License
//  * (LGPL) version 2.1 which accompanies this distribution, and is available at
//  * http://www.gnu.org/licenses/lgpl-2.1.html
//  *
//  *  Filename:	IFluentBuilder.cs
//  *  Date:		10/02/2014
//  *  Author:   	Denis Korkhov
//  *
//  */
#endregion
using System;
using System.Linq.Expressions;

namespace Cortoxa.Common.Fluent
{
    public interface IFluentBuilder
    {
        void Set<T>(Expression<Func<T, object>> expression, object value) where T : class, new();

        void Build();
    }
}
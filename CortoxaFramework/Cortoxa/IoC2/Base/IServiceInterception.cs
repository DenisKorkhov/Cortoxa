﻿#region Copyright © 2014 Denis Korkhov, Oxagile (http://www.oxagile.com/)
// /*
//  * All rights reserved. This program and the accompanying materials
//  * are made available under the terms of the GNU Lesser General Public License
//  * (LGPL) which accompanies this distribution, and is available at
//  * http://www.gnu.org/licenses/lgpl.html
//  *
//  *  Filename:	IServiceInterception.cs
//  *  Date:		21/02/2014
//  *  Author:   	Denis Korkhov
//  *
//  */
#endregion

using System;
using System.Linq.Expressions;
using Cortoxa.IoC.Interception;

namespace Cortoxa.IoC2.Base
{
    public interface IServiceInterception //: ISubBuilder<IServiceBuilder>
    {
        #region Replace
        IServiceInterception Replace<T>(Expression<Action<T>> methodExpr, Func<InterceptionContext, object> action);

        IServiceInterception Replace(string methodName, Func<InterceptionContext, object> action);

        IServiceInterception Replace(Func<InterceptionContext, object> action); 
        #endregion

        #region Before
        IServiceInterception Before<T>(Expression<Action<T>> methodExpr, Func<InterceptionContext, object> action);

        IServiceInterception Before(string methodName, Func<InterceptionContext, object> action);

        IServiceInterception Before(Func<InterceptionContext, object> action); 
        #endregion

        #region After
        IServiceInterception After<T>(Expression<Action<T>> methodExpr, Func<InterceptionContext, object> action);

        IServiceInterception After(string methodName, Func<InterceptionContext, object> action);

        IServiceInterception After(Func<InterceptionContext, object> action); 
        #endregion
    }
}
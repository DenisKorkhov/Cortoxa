#region Copyright © 2014 Denis Korkhov, Oxagile (http://www.oxagile.com/)

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

namespace Cortoxa.IoC.Base
{
    public interface IServiceInterception //: ISubBuilder<IServiceBuilder>
    {
        #region Replace

        IServiceBuilder Method<T>(Expression<Action<T>> methodExpr, Func<InterceptionContext, object> action);

        IServiceBuilder Method<T>(Expression<Action<T>> methodExpr, Action<InterceptionContext> action);

        IServiceBuilder Method(Func<InterceptionContext, object> action);

        IServiceBuilder Method(Action<InterceptionContext> action);

        #endregion

        #region Before

        IServiceBuilder Before<T>(Expression<Action<T>> methodExpr, Func<InterceptionContext, object> action);

        IServiceBuilder Before<T>(Expression<Action<T>> methodExpr, Action<InterceptionContext> action);

        IServiceBuilder Before(Func<InterceptionContext, object> action);

        IServiceBuilder Before(Action<InterceptionContext> action);

        #endregion

        #region After

        IServiceBuilder After<T>(Expression<Action<T>> methodExpr, Func<InterceptionContext, object> action);

        IServiceBuilder After<T>(Expression<Action<T>> methodExpr, Action<InterceptionContext> action);

        IServiceBuilder After(Func<InterceptionContext, object> action);

        IServiceBuilder After(Action<InterceptionContext> action);

        #endregion
    }
}
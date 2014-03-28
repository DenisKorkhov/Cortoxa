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

namespace Cortoxa.Container.Services
{
    public interface IServiceInterception //: ISubBuilder<IServiceBuilder>
    {
        #region Replace

        IServiceConfiguration Method<T>(Expression<Action<T>> methodExpr, Func<InterceptionContext, object> action);

        IServiceConfiguration Method<T>(Expression<Action<T>> methodExpr, Action<InterceptionContext> action);

        IServiceConfiguration Method(Func<InterceptionContext, object> action);

        IServiceConfiguration Method(Action<InterceptionContext> action);

        #endregion

        #region Before

        IServiceConfiguration Before<T>(Expression<Action<T>> methodExpr, Func<InterceptionContext, object> action);

        IServiceConfiguration Before<T>(Expression<Action<T>> methodExpr, Action<InterceptionContext> action);

        IServiceConfiguration Before(Func<InterceptionContext, object> action);

        IServiceConfiguration Before(Action<InterceptionContext> action);

        #endregion

        #region After

        IServiceConfiguration After<T>(Expression<Action<T>> methodExpr, Func<InterceptionContext, object> action);

        IServiceConfiguration After<T>(Expression<Action<T>> methodExpr, Action<InterceptionContext> action);

        IServiceConfiguration After(Func<InterceptionContext, object> action);

        IServiceConfiguration After(Action<InterceptionContext> action);

        #endregion
    }
}
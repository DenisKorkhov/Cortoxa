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
using Cortoxa.IoC.Base.ServiceFamily;
using Cortoxa.IoC.Interception;

namespace Cortoxa.IoC.Common
{
    public interface IServiceInterception //: ISubBuilder<IServiceBuilder>
    {
        #region Replace

        Base.ServiceFamily.IServiceBuilder Method<T>(Expression<Action<T>> methodExpr, Func<InterceptionContext, object> action);

        Base.ServiceFamily.IServiceBuilder Method<T>(Expression<Action<T>> methodExpr, Action<InterceptionContext> action);

        Base.ServiceFamily.IServiceBuilder Method(Func<InterceptionContext, object> action);

        Base.ServiceFamily.IServiceBuilder Method(Action<InterceptionContext> action);

        #endregion

        #region Before

        Base.ServiceFamily.IServiceBuilder Before<T>(Expression<Action<T>> methodExpr, Func<InterceptionContext, object> action);

        Base.ServiceFamily.IServiceBuilder Before<T>(Expression<Action<T>> methodExpr, Action<InterceptionContext> action);

        Base.ServiceFamily.IServiceBuilder Before(Func<InterceptionContext, object> action);

        Base.ServiceFamily.IServiceBuilder Before(Action<InterceptionContext> action);

        #endregion

        #region After

        Base.ServiceFamily.IServiceBuilder After<T>(Expression<Action<T>> methodExpr, Func<InterceptionContext, object> action);

        Base.ServiceFamily.IServiceBuilder After<T>(Expression<Action<T>> methodExpr, Action<InterceptionContext> action);

        Base.ServiceFamily.IServiceBuilder After(Func<InterceptionContext, object> action);

        Base.ServiceFamily.IServiceBuilder After(Action<InterceptionContext> action);

        #endregion
    }
}
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

        IServiceConfigurator Method<T>(Expression<Action<T>> methodExpr, Func<InterceptionContext, object> action);

        IServiceConfigurator Method<T>(Expression<Action<T>> methodExpr, Action<InterceptionContext> action);

        IServiceConfigurator Method(Func<InterceptionContext, object> action);

        IServiceConfigurator Method(Action<InterceptionContext> action);

        #endregion

        #region Before

        IServiceConfigurator Before<T>(Expression<Action<T>> methodExpr, Func<InterceptionContext, object> action);

        IServiceConfigurator Before<T>(Expression<Action<T>> methodExpr, Action<InterceptionContext> action);

        IServiceConfigurator Before(Func<InterceptionContext, object> action);

        IServiceConfigurator Before(Action<InterceptionContext> action);

        #endregion

        #region After

        IServiceConfigurator After<T>(Expression<Action<T>> methodExpr, Func<InterceptionContext, object> action);

        IServiceConfigurator After<T>(Expression<Action<T>> methodExpr, Action<InterceptionContext> action);

        IServiceConfigurator After<T>(string methodName, Action<InterceptionContext> action);

        IServiceConfigurator After(Func<InterceptionContext, object> action);

        IServiceConfigurator After(Action<InterceptionContext> action);

        #endregion

        IServiceConfigurator ByName(Action<InterceptionContext> action, string interceptorName);
    }
}
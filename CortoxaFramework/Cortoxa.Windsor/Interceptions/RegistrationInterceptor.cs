#region Copyright © 2014 Denis Korkhov, Oxagile (http://www.oxagile.com/)
// /*
//  * All rights reserved. This program and the accompanying materials
//  * are made available under the terms of the GNU Lesser General Public License
//  * (LGPL) version 2.1 which accompanies this distribution, and is available at
//  * http://www.gnu.org/licenses/lgpl-2.1.html
//  *
//  *  Filename:	RegistrationInterceptor.cs
//  *  Date:		05/02/2014
//  *  Author:   	Denis Korkhov
//  *
//  */
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Castle.DynamicProxy;
using Castle.MicroKernel.Context;
using Cortoxa.Container.Services;
using Cortoxa.Reflection;

namespace Cortoxa.Windsor.Interceptions
{
    public class RegistrationInterceptor : IInterceptor
    {
        private readonly IEnumerable<MethodInteception> interceptions;
        private readonly CreationContext context;
        private readonly IDictionary<string, object> metadata = new Dictionary<string, object>();

        public RegistrationInterceptor(IEnumerable<MethodInteception> interceptions, CreationContext context)
        {
            this.interceptions = interceptions;
            this.context = context;
        }

        public void Intercept(IInvocation invocation)
        {
            var actions = GetBeforeActions(invocation.Method);
            var interceptionContext = new InterceptionContext
            {
                Method = invocation.Method,
                ResolverType = context.Handler != null ? context.Handler.ComponentModel.Implementation : null,
                RequestedType = invocation.Method.DeclaringType,
                Arguments = invocation.Arguments,
                Metadata = metadata,
            };
            foreach (var action in actions)
            {
                action.DynamicInvoke(new object[] { interceptionContext });
            }

            interceptionContext.Procced = invocation.Proceed;

            var proccedAction = GetProceedActions((ctx) =>
            {
                invocation.Proceed();
                ctx.Result = invocation.ReturnValue;
            }, invocation.Method);

            proccedAction(interceptionContext);
            invocation.ReturnValue = interceptionContext.Result;

            interceptionContext.Procced = null;
            actions = GetAfterActions(invocation.Method);
            foreach (var action in actions)
            {
                action.DynamicInvoke(new object[] { interceptionContext });
            }
        }

        private Action<InterceptionContext> GetProceedActions(Action<InterceptionContext> rootAction, MethodInfo method)
        {
            var interceptors = interceptions.Where(x => x.Mode == MethodInteceptionType.Process && (x.Method == null || x.Method.EqualTo(method))).ToArray();
            Action<InterceptionContext> result = rootAction;
            for (int i = interceptors.Length - 1; i >= 0; i--)
            {
                var interceptor = interceptors[i];
                var prevAction = result;
                result = (ctx) =>
                {
                    var clousureAction = prevAction;
                    ctx.Procced = ()=>clousureAction(ctx);
                    interceptor.Action.DynamicInvoke(new object[] { ctx });
                };
            }
            return result;
        }

        private IEnumerable<Delegate> GetBeforeActions(MethodInfo method)
        {
            return interceptions.Where(x => x.Mode == MethodInteceptionType.Before && (x.Method == null || x.Method.EqualTo(method))).Select(x => x.Action).ToArray();
        }

        private IEnumerable<Delegate> GetAfterActions(MethodInfo method)
        {
            return interceptions.Where(x => x.Mode == MethodInteceptionType.After && (x.Method == null || x.Method.EqualTo(method))).Select(x => x.Action).ToArray();
        }
        
    }
}
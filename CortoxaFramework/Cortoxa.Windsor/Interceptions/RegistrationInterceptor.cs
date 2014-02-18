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
using Cortoxa.IoC;
using Cortoxa.IoC.Interception;

namespace Cortoxa.Windsor.Interceptions
{
    public class RegistrationInterceptor : IInterceptor
    {
        private readonly IToolContainer container;
        private readonly IEnumerable<MethodInteception> interceptions;
        private readonly CreationContext context;
        private readonly IDictionary<string, object> metadata = new Dictionary<string, object>();

        public RegistrationInterceptor(IToolContainer container, IEnumerable<MethodInteception> interceptions, CreationContext context)
        {
            this.container = container;
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
                action.DynamicInvoke(new object[] { container, interceptionContext });
            }

            interceptionContext.Procced = invocation.Proceed;

            var proccedAction = GetProceedActions(() =>
            {
                invocation.Proceed();
                interceptionContext.Result = invocation.ReturnValue;
            }, invocation.Method, interceptionContext);

            proccedAction();
            invocation.ReturnValue = interceptionContext.Result;

            interceptionContext.Procced = null;
            actions = GetAfterActions(invocation.Method);
            foreach (var action in actions)
            {
                action.DynamicInvoke(new object[] { container, interceptionContext });
            }
        }

        private Action GetProceedActions(Action rootAction, MethodInfo method, InterceptionContext interceptionContext)
        {
            var interceptors = interceptions.Where(x => x.Mode == MethodInteceptionType.Process && (x.Method == null || AreMethodsEqual(x.Method, method))).ToArray();
            Action result = rootAction;
            for (int i = interceptors.Length - 1; i >= 0; i--)
            {
                var interceptor = interceptors[i];
                var prevAction = result;
                result = () =>
                {
                    var clousureAction = prevAction;
                    interceptionContext.Procced = clousureAction;
                    interceptionContext.Result = interceptor.Action.DynamicInvoke(new object[] { container, interceptionContext });
                };
            }
            return result;
        }

        private IEnumerable<Delegate> GetBeforeActions(MethodInfo method)
        {
            return interceptions.Where(x => x.Mode == MethodInteceptionType.Before && (x.Method == null || AreMethodsEqual(x.Method, method))).Select(x => x.Action).ToArray();
        }

        private IEnumerable<Delegate> GetAfterActions(MethodInfo method)
        {
            return interceptions.Where(x => x.Mode == MethodInteceptionType.After && (x.Method == null || AreMethodsEqual(x.Method, method))).Select(x => x.Action).ToArray();
        }

//        private Delegate GetReplaceAction(MethodInfo method)
//        {
//            var beforeActions = interceptions.Where(x => x.Mode == MethodInteceptionType.Replace && (x.Method == null || AreMethodsEqual(x.Method, method))).ToList();
//            if (beforeActions.Count() > 1)
//            {
//                throw new Exception(string.Format("More then one replacing action for method {0}", method.Name));
//            }
//            return beforeActions.Select(x => x.Action).SingleOrDefault();
//        }

        public bool AreMethodsEqual(MethodInfo first, MethodInfo second)
        {
            first = first.ReflectedType == first.DeclaringType ? first : first.DeclaringType.GetMethod(first.Name, first.GetParameters().Select(p => p.ParameterType).ToArray());
            second = second.ReflectedType == second.DeclaringType ? second : second.DeclaringType.GetMethod(second.Name, second.GetParameters().Select(p => p.ParameterType).ToArray());
            return first == second;
        }
    }
}
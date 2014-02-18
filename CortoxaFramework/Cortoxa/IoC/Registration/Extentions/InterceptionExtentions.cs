#region Copyright © 2014 Denis Korkhov, Oxagile (http://www.oxagile.com/)
// /*
//  * All rights reserved. This program and the accompanying materials
//  * are made available under the terms of the GNU Lesser General Public License
//  * (LGPL) version 2.1 which accompanies this distribution, and is available at
//  * http://www.gnu.org/licenses/lgpl-2.1.html
//  *
//  *  Filename:	InterceptionExtentions.cs
//  *  Date:		05/02/2014
//  *  Author:   	Denis Korkhov
//  *
//  */
#endregion
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using Cortoxa.IoC.Interception;

namespace Cortoxa.IoC.Registration.Extentions
{
    public static class InterceptionExtentions
    {
        public static IComponentRegistration Intercept(this IComponentRegistration registration, Func<IToolContainer, InterceptionContext, object> action)
        {
            var context = registration.Context;
            context.Interceptors.Add(new MethodInteception(action, MethodInteceptionType.Process));
            return registration;
        }

        public static IComponentRegistration InterceptMethod<T>(this IComponentRegistration registration, Expression<Action<T>> methodExpr, Func<IToolContainer, InterceptionContext, object> action)
        {
            var context = registration.Context;
            context.Interceptors.Add(new MethodInteception(action, MethodInteceptionType.Process, GetMethodFromExpression(methodExpr)));
            return registration;
        }

        public static IComponentRegistration InterceptMethod<T>(this IComponentRegistration registration, Expression<Action<T>> methodExpr, Action<IToolContainer, InterceptionContext> action)
        {
            var context = registration.Context;
            context.Interceptors.Add(new MethodInteception(action, MethodInteceptionType.Process, GetMethodFromExpression(methodExpr)));
            return registration;
        }

//        public static IComponentRegistration InterceptReplace(this IComponentRegistration registration, Func<IToolContainer, InterceptionContext, object> action)
//        {
//            var context = registration.Context;
//            context.Interceptors.Add(new MethodInteception(action, MethodInteceptionType.Replace));
//            return registration;
//        }

        public static IComponentRegistration InterceptAfter(this IComponentRegistration registration, Func<IToolContainer, InterceptionContext, object> action)
        {
            var context = registration.Context;
            context.Interceptors.Add(new MethodInteception(action, MethodInteceptionType.After));
            return registration;
        }

        public static IComponentRegistration InterceptMethodReplace<T>(this IComponentRegistration registration, Expression<Action<T>> methodExpr, Func<IToolContainer, InterceptionContext, object> action)
        {
            var context = registration.Context;
            context.Interceptors.Add(new MethodInteception(action, MethodInteceptionType.Replace, GetMethodFromExpression(methodExpr)));
            return registration;
        }

        public static MethodInfo GetMethodFromExpression<T>(this Expression<Action<T>> methodExpr)
        {
	        var call = methodExpr.Body as MethodCallExpression;
	        if (call == null)
	        {
		        throw new InvalidOperationException("Expression must be a method call");
	        }

	        if (call.Object != methodExpr.Parameters[0])
	        {
		        throw new InvalidOperationException("Method call must target lambda argument");
	        }
	        return call.Method;
        }
    }
}
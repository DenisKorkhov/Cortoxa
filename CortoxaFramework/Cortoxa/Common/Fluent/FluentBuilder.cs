#region Copyright © 2014 
// /*
//  * All rights reserved. This program and the accompanying materials
//  * are made available under the terms of the GNU Lesser General Public License
//  * (LGPL) version 2.1 which accompanies this distribution, and is available at
//  * http://www.gnu.org/licenses/lgpl-2.1.html
//  *
//  *  Filename:	FluentBuilder.cs
//  *  Date:		05/02/2014
//  *  Author:   	Denis Korkhov
//  *
//  */
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Cortoxa.Common.Fluent
{
    public abstract class FluentBuilder : IFluentBuilder
    {
        protected readonly IList<object> Context = new List<object>();
        private static readonly object LockObject = new object();

        public void Set<T>(Expression<Func<T, object>> expression, object value) where T : class, new()
        {
            var body = expression.Body as MemberExpression ?? ((UnaryExpression)expression.Body).Operand as MemberExpression;

            var propertyInfo = (PropertyInfo)body.Member;
            var settingsObject = Get<T>();
            #if NET35 || NET40
                propertyInfo.SetValue(settingsObject, value, null);
            #else
            propertyInfo.SetValue(settingsObject, value);
            #endif
        }

        public TR Get<T, TR>(Expression<Func<T, object>> expression) where T : class, new()
        {
            var body = expression.Body as MemberExpression ?? ((UnaryExpression)expression.Body).Operand as MemberExpression;
            var propertyInfo = (PropertyInfo)body.Member;
            var settingsObject = Get<T>();
            
            #if NET35 || NET40
            return (TR)propertyInfo.GetValue(settingsObject, null);
            #else
            return (TR)propertyInfo.GetValue(settingsObject);
            #endif
        }

        public T Get<T>() where T : class, new()
        {
            if (Context.All(x => x.GetType() != typeof (T)))
            {
                lock (LockObject)
                {
                    if (Context.All(x => x.GetType() != typeof (T)))
                    {
                        Context.Add(new T());
                    }
                }
            }
            return (T)Context.FirstOrDefault(x => x.GetType() == typeof (T));
        }

        public abstract void Build();
    }
}
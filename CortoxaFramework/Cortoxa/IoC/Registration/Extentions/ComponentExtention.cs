#region Copyright © 2014 Denis Korkhov, Oxagile (http://www.oxagile.com/)
// /*
//  * All rights reserved. This program and the accompanying materials
//  * are made available under the terms of the GNU Lesser General Public License
//  * (LGPL) version 2.1 which accompanies this distribution, and is available at
//  * http://www.gnu.org/licenses/lgpl-2.1.html
//  *
//  *  Filename:	ComponentExtention.cs
//  *  Date:		05/02/2014
//  *  Author:   	Denis Korkhov
//  *
//  */
#endregion
using System;

namespace Cortoxa.IoC.Registration.Extentions
{
    public static class ComponentExtention
    {
        public static IComponentRegistration ToFactory<T>(this IComponentRegistration registration, Func<FactoryContext, T> action)
        {
            var context = registration.Context;
            context.ToFactory = (R) => action(R);
            return registration;
        }

        public static IComponentRegistration ToFactory(this IComponentRegistration registration, Func<FactoryContext, object> action)
        {
            var context = registration.Context;
            context.ToFactory = action;
            return registration;
        }  
    }
}
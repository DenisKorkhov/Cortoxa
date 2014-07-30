#region Copyright © 2014 
// /*
//  * All rights reserved. This program and the accompanying materials
//  * are made available under the terms of the GNU Lesser General Public License
//  * (LGPL) version 2.1 which accompanies this distribution, and is available at
//  * http://www.gnu.org/licenses/lgpl-2.1.html
//  *
//  *  Filename:	WebPageHandlerFactory.cs
//  *  Date:		17/02/2014
//  *  Author:   	Denis Korkhov
//  *
//  */
#endregion
using System;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;

namespace Cortoxa.Web.MVC.Factories
{
    public class WebPageHandlerFactory : PageHandlerFactory
    {
        private static object GetInstance(Type type)
        {
            return null;
        }

        public override IHttpHandler GetHandler(HttpContext cxt, string type, string vPath, string path)
        {
            IHttpHandler page = base.GetHandler(cxt, type, vPath, path);
            if (page != null)
            {
                InjectDependencies(page);
            }

            return page;
        }

        private static void InjectDependencies(object page)
        {
            Type pageType = page.GetType().BaseType;

            ConstructorInfo ctor = GetInjectableCtor(pageType);

            if (ctor != null)
            {
                object[] arguments = ctor.GetParameters().Select(x => GetInstance(x.ParameterType)).ToArray();
                ctor.Invoke(page, arguments);
            }
        }

        private static ConstructorInfo GetInjectableCtor(Type type)
        {
            ConstructorInfo[] overloadedPublicConstructors =
                type.GetConstructors().Where(x => x.GetParameters().Length > 0).ToArray();

            if (overloadedPublicConstructors.Length == 0)
            {
                return null;
            }

            if (overloadedPublicConstructors.Length == 1)
            {
                return overloadedPublicConstructors[0];
            }

            throw new Exception(string.Format(
                "The type {0} has multiple public " +
                "ctors and can't be initialized.", type));
        }
    }
}
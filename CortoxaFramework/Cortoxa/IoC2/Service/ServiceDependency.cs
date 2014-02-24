#region Copyright © 2014 Denis Korkhov, Oxagile (http://www.oxagile.com/)
// /*
//  * All rights reserved. This program and the accompanying materials
//  * are made available under the terms of the GNU Lesser General Public License
//  * (LGPL) which accompanies this distribution, and is available at
//  * http://www.gnu.org/licenses/lgpl.html
//  *
//  *  Filename:	IServiceDependency.cs
//  *  Date:		21/02/2014
//  *  Author:   	Denis Korkhov
//  *
//  */
#endregion

using Cortoxa.IoC2.Base;

namespace Cortoxa.IoC2.Service
{
    public static class ServiceDependency
    {
        public static IServiceBuilder On<T>(this IServiceBuilder service, string dependencyName)
        {
            return service;
        }

        public static IServiceBuilder On<T>(this IServiceBuilder service, string serviceName, string dependencyName)
        {
            return service;
        }
    }
}
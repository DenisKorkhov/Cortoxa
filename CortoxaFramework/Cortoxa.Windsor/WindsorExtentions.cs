#region Copyright © 2014 Denis Korkhov, Oxagile (http://www.oxagile.com/)
// /*
//  * All rights reserved. This program and the accompanying materials
//  * are made available under the terms of the GNU Lesser General Public License
//  * (LGPL) version 2.1 which accompanies this distribution, and is available at
//  * http://www.gnu.org/licenses/lgpl-2.1.html
//  *
//  *  Filename:	WindsorExtentions.cs
//  *  Date:		05/02/2014
//  *  Author:   	Denis Korkhov
//  *
//  */
#endregion
using System;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Cortoxa.IoC;
using Cortoxa.IoC.Attributes;

namespace Cortoxa.Windsor
{
    public static class WindsorExtentions
    {
        public static BasedOnDescriptor ToWindsorLifeTime(this BasedOnDescriptor container, ToolkitLifeTime lifeTime)
        {
            switch (lifeTime)
            {
                case ToolkitLifeTime.Singleton:
                    return container.LifestyleSingleton();
                case ToolkitLifeTime.PerWebRequest:
                    return container.LifestylePerWebRequest();
                case ToolkitLifeTime.PerThread:
                    return container.LifestylePerThread();
                default:
                    return container.LifestyleTransient();
            }
        }

        public static ComponentRegistration<T> ToWindsorLifeTime<T>(this ComponentRegistration<T> container,ToolkitLifeTime lifeTime) where T : class
        {
            switch (lifeTime)
            {
                case ToolkitLifeTime.Singleton:
                    return container.LifeStyle.Singleton;
                case ToolkitLifeTime.PerWebRequest:
                    return container.LifeStyle.PerWebRequest;
                case ToolkitLifeTime.PerThread:
                    return container.LifeStyle.PerThread;
                default:
                    return container.LifeStyle.Transient;
            }
        }

        public static ComponentRegistration<object> ToWindsorLifeTime(this ComponentRegistration<object> container, ToolkitLifeTime lifeTime)
        {
            return ToWindsorLifeTime<object>(container, lifeTime);
        }
    }
}
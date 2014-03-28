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

using Castle.MicroKernel.Registration;
using Cortoxa.Container.Life;

namespace Cortoxa.Windsor.Helpers
{
    public static class WindsorExtentions
    {
        public static BasedOnDescriptor ToWindsorLifeTime(this BasedOnDescriptor container, LifeTime lifeTime)
        {
            switch (lifeTime)
            {
                case LifeTime.Singleton:
                    return container.LifestyleSingleton();
                case LifeTime.PerWebRequest:
                    return container.LifestylePerWebRequest();
                case LifeTime.PerThread:
                    return container.LifestylePerThread();
                default:
                    return container.LifestyleTransient();
            }
        }

        public static ComponentRegistration<T> ToWindsorLifeTime<T>(this ComponentRegistration<T> container,LifeTime lifeTime) where T : class
        {
            switch (lifeTime)
            {
                case LifeTime.Singleton:
                    return container.LifeStyle.Singleton;
                case LifeTime.PerWebRequest:
                    return container.LifeStyle.PerWebRequest;
                case LifeTime.PerThread:
                    return container.LifeStyle.PerThread;
                default:
                    return container.LifeStyle.Transient;
            }
        }

        public static ComponentRegistration<object> ToWindsorLifeTime(this ComponentRegistration<object> container, LifeTime lifeTime)
        {
            return ToWindsorLifeTime<object>(container, lifeTime);
        }
    }
}
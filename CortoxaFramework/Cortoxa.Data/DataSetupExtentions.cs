#region Copyright © 2014 Denis Korkhov, Oxagile (http://www.oxagile.com/)
// /*
//  * All rights reserved. This program and the accompanying materials
//  * are made available under the terms of the GNU Lesser General Public License
//  * (LGPL) which accompanies this distribution, and is available at
//  * http://www.gnu.org/licenses/lgpl.html
//  *
//  *  Filename:	DataSetupExtentions.cs
//  *  Date:		17/02/2014
//  *  Author:   	Denis Korkhov
//  *
//  */
#endregion
using System;
using Cortoxa.Data.IoC;
using Cortoxa.IoC.Base;

namespace Cortoxa.Data
{
    public static class DataSetupExtentions 
    {
        public static IDataConfig WithContext<T>(this IDataConfig config, LifeTime lifeTime = LifeTime.Transient)
        {
            return WithContext(config, typeof (T), lifeTime);
        }

        public static IDataConfig WithContext(this IDataConfig config, Type type, LifeTime lifeTime = LifeTime.Transient)
        {
            config.Configure<ContextConfiguration>(c =>
            {
                c.Type = type;
                c.LifeTime = lifeTime;
            });
            return config;
        }

        public static IDataConfig WithRepository<T>(this IDataConfig config, LifeTime lifeTime = LifeTime.Transient)
        {
            return WithRepository(config, typeof(T), lifeTime);
        }

        public static IDataConfig WithRepository(this IDataConfig config, Type type, LifeTime lifeTime = LifeTime.Transient)
        {
            config.Configure<RepositoryConfiguration>(c =>
            {
                c.Type = type;
                c.LifeTime = lifeTime;
            });
            return config;
        }
    }
}
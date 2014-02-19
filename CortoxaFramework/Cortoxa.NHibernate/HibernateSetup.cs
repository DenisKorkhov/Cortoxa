#region Copyright © 2014 Denis Korkhov, Oxagile (http://www.oxagile.com/)
// /*
//  * All rights reserved. This program and the accompanying materials
//  * are made available under the terms of the GNU Lesser General Public License
//  * (LGPL) version 2.1 which accompanies this distribution, and is available at
//  * http://www.gnu.org/licenses/lgpl-2.1.html
//  *
//  *  Filename:	HibernateSetup.cs
//  *  Date:		17/02/2014
//  *  Author:   	Denis Korkhov
//  *
//  */
#endregion

using System;
using System.Reflection;
using Cortoxa.Common;
using Cortoxa.Data.IoC;
using Cortoxa.Data.NHibernate.Context;
using Cortoxa.Data.NHibernate.IoC;
using Cortoxa.Data.Repository;
using Cortoxa.IoC.Attributes;

namespace Cortoxa.Data.NHibernate
{
    public static class HibernateSetup
    {
        public static IStoreSetup UseHibernate(this IToolSetup<IStoreSetup> dataSetup, string connectionString, Assembly sourceAssembly, ToolkitLifeTime lifeTime = ToolkitLifeTime.PerWebRequest, bool buildSchema = false)
        {
            return new HibernateStoreSetup("hibernate_{0}".Format(Guid.NewGuid()), connectionString, sourceAssembly)
                .WithSession<HibernateSession>()
                .WithRepository(typeof (Store<>));
        }
    }
}
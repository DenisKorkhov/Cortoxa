#region Copyright © 2014 Denis Korkhov, Oxagile (http://www.oxagile.com/)
// /*
//  * All rights reserved. This program and the accompanying materials
//  * are made available under the terms of the GNU Lesser General Public License
//  * (LGPL) which accompanies this distribution, and is available at
//  * http://www.gnu.org/licenses/lgpl.html
//  *
//  *  Filename:	EntitySetup.cs
//  *  Date:		19/02/2014
//  *  Author:   	Denis Korkhov
//  *
//  */
#endregion

using System;
using System.Reflection;
using Cortoxa.Common;
using Cortoxa.Data.EntityFramework.Context;
using Cortoxa.Data.EntityFramework.IoC;
using Cortoxa.Data.IoC;
using Cortoxa.Data.Repository;
using Cortoxa.IoC.Attributes;

namespace Cortoxa.Data.EntityFramework
{
    public static class EntitySetup
    {

        public static IStoreSetup UseEntityFramework(this IToolSetup<IStoreSetup> dataSetup, Type contextType, ToolkitLifeTime lifeTime = ToolkitLifeTime.PerWebRequest, bool buildSchema = false)
        {
            return new EntityStoreSetup("entity_{0}".Format(Guid.NewGuid()), contextType)
                .WithSession<EntitySession>()
                .WithRepository(typeof(Store<>));
        }
    }
}
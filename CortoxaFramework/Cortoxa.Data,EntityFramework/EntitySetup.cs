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

using Cortoxa.Container.Common;
using Cortoxa.Container.Components;
using Cortoxa.Container.Services;
using Cortoxa.Data.Common;
using Cortoxa.Data.EntityFramework.Component;

namespace Cortoxa.Data.EntityFramework
{
    public static class EntitySetup
    {
        public static IComponentConfigurator<EntityComponent> EntityFramework(this IComponentRegistrator componentRegistrator)
        {
            return componentRegistrator.Configure<EntityComponent>(c=>c.Source, r => r.For<IDataSource>().To<EntityDataSource>().LifeTime(LifeTime.Transient));
        }
}
}
#region Copyright © 2014 
// /*
//  * All rights reserved. This program and the accompanying materials
//  * are made available under the terms of the GNU Lesser General Public License
//  * (LGPL) version 2.1 which accompanies this distribution, and is available at
//  * http://www.gnu.org/licenses/lgpl-2.1.html
//  *
//  *  Filename:	IdentitySetup.cs
//  *  Date:		17/02/2014
//  *  Author:   	Denis Korkhov
//  *
//  */
#endregion

using System;
using Cortoxa.Container.Component;
using Cortoxa.Container.Extentions;
using Cortoxa.Container.Registrator;
using Cortoxa.Data.Identity.Container;
using Cortoxa.Data.Identity.Entitites;
using Cortoxa.Data.Identity.Repositories;
using Microsoft.AspNet.Identity;

namespace Cortoxa.Data.Identity
{

    public static class IdentitySetup
    {
        public static IComponentConfigurator<IdentityContext> Identity(this IRegistration registration)
        {
            var configurator = new ComponentConfigurator<IdentityContext>(registration, new IdentityContext());
            configurator.Configure(c =>
            {
                c.ClaimType = typeof (IdentityUserClaim<>);
            });

            configurator.Register((r, c) =>
            {
                Type userClaimType = c.ClaimType.MakeGenericType(c.UserType);

                Type userStoreInterface = typeof(IUserStore<,>).MakeGenericType(c.UserType, typeof(Guid));

                Type userStoreClass = typeof(UserStore<,,>).MakeGenericType(c.UserType, c.RoleType, userClaimType);

                Type userManagerBase = typeof(UserManager<,>).MakeGenericType(c.UserType, typeof(Guid));
                Type userManagerClass = c.UserManagerType ?? typeof (UserManager<,>).MakeGenericType(c.UserType, typeof(Guid));
                
                r.For(userStoreInterface).To(userStoreClass).LifeTime(c.LifeTime);
                r.For(userManagerBase).To(userManagerClass).LifeTime(c.LifeTime);
            });
            return configurator;
        }

        public static IComponentConfigurator<IdentityContext> User<T>( this IComponentConfigurator<IdentityContext> configurator)
        {
            configurator.Configure(c=>c.UserType = typeof(T));
            return configurator;
        }

        public static IComponentConfigurator<IdentityContext> Role<T>(this IComponentConfigurator<IdentityContext> configurator)
        {
            configurator.Configure(c => c.RoleType = typeof(T));
            return configurator;
        }

        public static IComponentConfigurator<IdentityContext> UserManager<T>(this IComponentConfigurator<IdentityContext> configurator)
        {
            configurator.Configure(c => c.UserManagerType = typeof(T));
            return configurator;
        }
    }
}
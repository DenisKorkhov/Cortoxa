#region Copyright © 2014 Denis Korkhov, Oxagile (http://www.oxagile.com/)
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
                Type userManagerClass = typeof(UserManager<,>).MakeGenericType(c.UserType, typeof(Guid));
                
                r.For(userStoreInterface).To(userStoreClass).LifeTime(c.LifeTime);
                r.For(userManagerClass).To(userManagerClass).LifeTime(c.LifeTime);
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


//        public static IComponentConfigurator<IdentityContext> WithIdentity()
//        {
//             Type userStoreInterface = typeof(IUserStore<>).MakeGenericType(userType);
//            Type userStoreClass = typeof(UserStore<>).MakeGenericType(userType);
//            Type userManagerClass = typeof(UserManager<>).MakeGenericType(userType);
//        }

//        public static IDataConfig WithIdentityModel(this IDataConfig config)
//        {
//            IModelBuilder modelBuilder = null;
//            ITableModel<IdentityUser> userModel = modelBuilder.ForEntity<IdentityUser>("User")
//                .Id(x => x.Id)
//                .Property(x => x.UserName)
//                .Property(x => x.PasswordHash)
//                .Property(x => x.SecurityStamp)
//                .OneToMany(x => x.Claims, null)
//                .ManyToMany(x => x.Roles, null);
//
//            ITableModel<IdentityRole> roleModel = modelBuilder.ForEntity<IdentityRole>("Role")
//                .Id(x => x.Id)
//                .Property(x => x.Name)
//                .ManyToMany(x => x.Users, null);
//
//            config.Configure(new IdentityConfig(typeof (IdentityUser)));
//            return config;
//        }
    }
}
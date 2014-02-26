#region Copyright © 2014 Denis Korkhov, Oxagile (http://www.oxagile.com/)
// /*
//  * All rights reserved. This program and the accompanying materials
//  * are made available under the terms of the GNU Lesser General Public License
//  * (LGPL) version 2.1 which accompanies this distribution, and is available at
//  * http://www.gnu.org/licenses/lgpl-2.1.html
//  *
//  *  Filename:	IdentityConfig.cs
//  *  Date:		17/02/2014
//  *  Author:   	Denis Korkhov
//  *
//  */
#endregion

using System;
using Cortoxa.Data.Identity.Repositories;
using Cortoxa.IoC;
using Cortoxa.IoC.Base;
using Microsoft.AspNet.Identity;

namespace Cortoxa.Data.Identity.IoC
{
    public class IdentityConfig : IRegistrationStratagy
    {
        private readonly Type userType;

        public IdentityConfig(Type userType)
        {
            this.userType = userType;
        }

        public void Register(IToolRegistrator container)
        {

            Type userStoreInterface = typeof(IUserStore<>).MakeGenericType(userType);
            Type userStoreClass = typeof(UserStore<>).MakeGenericType(userType);
            Type userManagerClass = typeof(UserManager<>).MakeGenericType(userType);
            
//            container.Register(r => r.For(userStoreInterface).To(userStoreClass).LifeTime(LifeTime.Transient))
//                .Register(r => r.For(userManagerClass).ToSelf().LifeTime(LifeTime.Transient));
        }
    }
}
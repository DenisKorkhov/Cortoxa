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
using Cortoxa.Data.IoC;
using Cortoxa.Data.Schema;
using Cortoxa.Data.Schema.Models;
using Cortoxa.Identity.Entitites;
using Cortoxa.Identity.IoC;

namespace Cortoxa.Identity
{
    public static class IdentitySetup
    {
        public static IDataConfig WithIdentityModel(this IDataConfig config)
        {
            IModelBuilder modelBuilder = null;
            ITableModel<IdentityUser> userModel = modelBuilder.ForEntity<IdentityUser>("User")
                .Id(x => x.Id)
                .Property(x => x.UserName)
                .Property(x => x.PasswordHash)
                .Property(x => x.SecurityStamp)
                .OneToMany(x => x.Claims, null)
                .ManyToMany(x => x.Roles, null);

            ITableModel<IdentityRole> roleModel = modelBuilder.ForEntity<IdentityRole>("Role")
                .Id(x => x.Id)
                .Property(x => x.Name)
                .ManyToMany(x => x.Users, null);

            config.Configure(new IdentityConfig(typeof (IdentityUser)));
            return config;
        }
    }
}
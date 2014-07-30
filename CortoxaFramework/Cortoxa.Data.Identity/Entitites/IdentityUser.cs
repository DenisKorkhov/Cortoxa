#region Copyright © 2014 
// /*
//  * All rights reserved. This program and the accompanying materials
//  * are made available under the terms of the GNU Lesser General Public License
//  * (LGPL) version 2.1 which accompanies this distribution, and is available at
//  * http://www.gnu.org/licenses/lgpl-2.1.html
//  *
//  *  Filename:	IdentityUser.cs
//  *  Date:		10/02/2014
//  *  Author:   	Denis Korkhov
//  *
//  */
#endregion

using System;
using System.Collections.Generic;
using Cortoxa.Data.Model;
using Microsoft.AspNet.Identity;

namespace Cortoxa.Data.Identity.Entitites
{
    public class IdentityUser<TRole, TClaim> : Entity, IUser<Guid>
    {
        public virtual string UserName { get; set; }

        public virtual string Email { get; set; }

        public virtual string PhoneNumber { get; set; }

        public virtual string PasswordHash { get; set; }

        public virtual string SecurityStamp { get; set; }

        public virtual DateTime? LockoutEndDate { get; set; }

        public virtual bool LockoutEnabled { get; set; }

        public virtual int AccessFailedCount { get; set; }

        public virtual ICollection<TRole> Roles { get; set; }

        public virtual ICollection<TClaim> Claims { get; set; }
    }
}
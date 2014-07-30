#region Copyright © 2014 
// /*
//  * All rights reserved. This program and the accompanying materials
//  * are made available under the terms of the GNU Lesser General Public License
//  * (LGPL) version 2.1 which accompanies this distribution, and is available at
//  * http://www.gnu.org/licenses/lgpl-2.1.html
//  *
//  *  Filename:	IdentityRole.cs
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
    public class IdentityRole<TUser> : Entity, IRole<Guid> //where TUser : IUser<Guid>
    {
        #region Constructor

        public IdentityRole(): this("")
        {
        }

        public IdentityRole(string roleName)
        {
            this.Name = roleName;
        }

        #endregion

        public virtual string Name { get; set; }

        public virtual ICollection<TUser> Users { get; set; }
    }
}
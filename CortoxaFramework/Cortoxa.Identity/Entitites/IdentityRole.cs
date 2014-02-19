#region Copyright © 2014 Denis Korkhov, Oxagile (http://www.oxagile.com/)
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
using Microsoft.AspNet.Identity;

namespace Cortoxa.Data.Identity.Entitites
{
    public class IdentityRole : Entity, IRole
    {

        #region Constructor

        public IdentityRole()
            : this("")
        {
        }

        public IdentityRole(string roleName)
        {
            this.Id = Guid.NewGuid();
            this.Name = roleName;
        }

        #endregion

        string IRole.Id
        {
            get { return Id.ToString(); }
        }
        public virtual string Name { get; set; }

        public virtual ICollection<IdentityUser> Users { get; set; }
    }
}
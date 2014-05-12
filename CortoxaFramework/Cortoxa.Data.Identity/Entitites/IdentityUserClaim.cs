#region Copyright © 2014 Denis Korkhov, Oxagile (http://www.oxagile.com/)
// /*
//  * All rights reserved. This program and the accompanying materials
//  * are made available under the terms of the GNU Lesser General Public License
//  * (LGPL) version 2.1 which accompanies this distribution, and is available at
//  * http://www.gnu.org/licenses/lgpl-2.1.html
//  *
//  *  Filename:	IdentityUserClaim.cs
//  *  Date:		17/02/2014
//  *  Author:   	Denis Korkhov
//  *
//  */
#endregion

using System;
using Cortoxa.Data.Model;
using Microsoft.AspNet.Identity;

namespace Cortoxa.Data.Identity.Entitites
{
    public class IdentityUserClaim<TUser> : Entity where TUser : IUser<Guid>
    {
        public virtual string ClaimType { get; set; }

        public virtual string ClaimValue { get; set; }

//        public virtual Guid UserId { get; set; }

        public virtual TUser User { get; set; }
    }
}
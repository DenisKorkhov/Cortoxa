#region Copyright © 2014 Denis Korkhov, Oxagile (http://www.oxagile.com/)
// /*
//  * All rights reserved. This program and the accompanying materials
//  * are made available under the terms of the GNU Lesser General Public License
//  * (LGPL) version 2.1 which accompanies this distribution, and is available at
//  * http://www.gnu.org/licenses/lgpl-2.1.html
//  *
//  *  Filename:	UserStore.cs
//  *  Date:		17/02/2014
//  *  Author:   	Denis Korkhov
//  *
//  */
#endregion

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Cortoxa.Data.Common;
using Cortoxa.Data.Context;
using Cortoxa.Data.Identity.Entitites;
using Cortoxa.Data.Repository;
using Microsoft.AspNet.Identity;

namespace Cortoxa.Data.Identity.Repositories
{
    public class UserStore<TUser> : IUserLoginStore<TUser>, IUserClaimStore<TUser>, IUserRoleStore<TUser>, IUserPasswordStore<TUser>, IUserSecurityStampStore<TUser> where TUser : IdentityUser
    {
        private bool disposed;
        private IStore<TUser> userRepository;
        private readonly IStore<IdentityRole> roleRepository;
        private readonly IStore<IdentityUserClaim> claimsRepository;
        private readonly IDbSession session;

        public bool AutoSaveChanges { get; set; }

        public UserStore(IStore<TUser> userRepository, IStore<IdentityRole> roleRepository, IStore<IdentityUserClaim> claimsRepository, IDbSession session)
        {
            this.userRepository = userRepository;
            this.roleRepository = roleRepository;
            this.claimsRepository = claimsRepository;
            this.session = session;

            AutoSaveChanges = true;
        }

        private async Task SaveChanges()
        {
            if (AutoSaveChanges)
            {
                await session.SaveChangesAsync();
            }
        }

        public virtual Task<TUser> FindByIdAsync(string userId)
        {
            ThrowIfDisposed();
            return userRepository.GetAsync(Guid.Parse(userId));
        }
        public virtual Task<TUser> FindByNameAsync(string userName)
        {
            ThrowIfDisposed();
            userName = userName.ToUpper();
            return Task.FromResult(userRepository.First(x => x.UserName.ToUpper() == userName));
        }
        public virtual async Task CreateAsync(TUser user)
        {
            this.ThrowIfDisposed();
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }
            userRepository.Add(user);
            await SaveChanges();
        }

        public virtual async Task DeleteAsync(TUser user)
        {
            ThrowIfDisposed();
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }
            userRepository.Delete(user);
            await SaveChanges();
        }

        public virtual async Task UpdateAsync(TUser user)
        {
            ThrowIfDisposed();
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }
            userRepository.Update(user);
            await SaveChanges();
        }

        private void ThrowIfDisposed()
        {
            if (disposed)
            {
                throw new ObjectDisposedException(base.GetType().Name);
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            disposed = true;
            session.Dispose();
            userRepository = null;
        }

        public virtual async Task<TUser> FindAsync(UserLoginInfo login)
        {
            ThrowIfDisposed();
            if (login == null)
            {
                throw new ArgumentNullException("login");
            }
//            IdentityUser identityUser = await userRepository.FirstAsync(x=>x.)
//            IdentityUser identityUser = await QueryableExtensions.FirstOrDefaultAsync<IdentityUser>(
//                from l in this._logins
//                where l.LoginProvider == login.LoginProvider && l.ProviderKey == login.ProviderKey
//                select l.User);
//
//            userRepository.First(x=>x.)
//            return identityUser as TUser;
            return await Task.FromResult(default(TUser));
        }
        public virtual Task AddLoginAsync(TUser user, UserLoginInfo login)
        {
            ThrowIfDisposed();
//            if (user == null)
//            {
//                throw new ArgumentNullException("user");
//            }
//            if (login == null)
//            {
//                throw new ArgumentNullException("login");
//            }
//            user.Logins.Add(new IdentityUserLogin
//            {
//                User = user,
//                ProviderKey = login.ProviderKey,
//                LoginProvider = login.LoginProvider
//            });
            return Task.FromResult<int>(0);
        }
        public virtual Task RemoveLoginAsync(TUser user, UserLoginInfo login)
        {
            ThrowIfDisposed();
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }
            if (login == null)
            {
                throw new ArgumentNullException("login");
            }
//            IdentityUserLogin identityUserLogin = (
//                from l in user.Logins
//                where l.LoginProvider == login.LoginProvider && l.User == user && l.ProviderKey == login.ProviderKey
//                select l).SingleOrDefault<IdentityUserLogin>();
//            if (identityUserLogin != null)
//            {
//                user.Logins.Remove(identityUserLogin);
//                this._logins.Remove(identityUserLogin);
//            }
            return Task.FromResult<int>(0);
        }

        public virtual Task<IList<UserLoginInfo>> GetLoginsAsync(TUser user)
        {
//            this.ThrowIfDisposed();
//            if (user == null)
//            {
//                throw new ArgumentNullException("user");
//            }
//            IList<UserLoginInfo> list = new List<UserLoginInfo>();
//            foreach (IdentityUserLogin current in user.Logins)
//            {
//                list.Add(new UserLoginInfo(current.LoginProvider, current.ProviderKey));
//            }
            return Task.FromResult<IList<UserLoginInfo>>(null);
        }
        public virtual Task<IList<Claim>> GetClaimsAsync(TUser user)
        {
            ThrowIfDisposed();
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }
            IList<Claim> list = user.Claims != null ? user.Claims.Select(x => new Claim(x.ClaimType, x.ClaimValue)).ToList() : new List<Claim>();
            return Task.FromResult(list);
        }
        public virtual Task AddClaimAsync(TUser user, Claim claim)
        {
            ThrowIfDisposed();
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }
            if (claim == null)
            {
                throw new ArgumentNullException("claim");
            }
            user.Claims.Add(new IdentityUserClaim
            {
                User = user,
                ClaimType = claim.Type,
                ClaimValue = claim.Value
            });
            return Task.FromResult(0);
        }
        public virtual Task RemoveClaimAsync(TUser user, Claim claim)
        {
            ThrowIfDisposed();
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }
            if (claim == null)
            {
                throw new ArgumentNullException("claim");
            }
            var claims = user.Claims.Where(x => x.ClaimValue == claim.Value && x.ClaimType == claim.Type).ToList();

            foreach (var userClaim in claims)
            {
                user.Claims.Remove(userClaim);
                claimsRepository.Delete(userClaim);
            }
            return Task.FromResult(0);
        }
        public virtual Task AddToRoleAsync(TUser user, string role)
        {
            ThrowIfDisposed();
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }
            role = role.ToUpper();
            IdentityRole identityRole = roleRepository.Single(r => r.Name.ToUpper() == role);
            if (identityRole == null)
            {
                throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, "RoleNotFound {0}", new object[] { role }));
            }
            

            user.Roles.Add(identityRole);
            return Task.FromResult(0);
        }
        public virtual Task RemoveFromRoleAsync(TUser user, string role)
        {
            ThrowIfDisposed();
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }

            role = role.ToUpper();

            var userRole = roleRepository.First(x=>x.Name == role);

            if (userRole != null)
            {
                user.Roles.Remove(userRole);
            }
            return Task.FromResult(0);
        }

        public virtual Task<IList<string>> GetRolesAsync(TUser user)
        {
            ThrowIfDisposed();
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }

            List<string> result = user.Roles != null ? user.Roles.Select(x => x.Name).ToList() : new List<string>();
            return Task.FromResult<IList<string>>(result);
        }

        public virtual Task<bool> IsInRoleAsync(TUser user, string role)
        {
            ThrowIfDisposed();
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }
            role = role.ToUpper();
            return Task.FromResult(user.Roles.Any(r => r.Name.ToUpper() == role));
        }

        public Task SetPasswordHashAsync(TUser user, string passwordHash)
        {
            ThrowIfDisposed();
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }
            user.PasswordHash = passwordHash;
            return Task.FromResult(0);
        }
        public Task<string> GetPasswordHashAsync(TUser user)
        {
            ThrowIfDisposed();
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }
            return Task.FromResult(user.PasswordHash);
        }

        public Task SetSecurityStampAsync(TUser user, string stamp)
        {
            ThrowIfDisposed();
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }
            user.SecurityStamp = stamp;
            return Task.FromResult(0);
        }

        public Task<string> GetSecurityStampAsync(TUser user)
        {
            ThrowIfDisposed();
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }
            return Task.FromResult(user.SecurityStamp);
        }

        public Task<bool> HasPasswordAsync(TUser user)
        {
            return Task.FromResult(user.PasswordHash != null);
        }
    }
};
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
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Cortoxa.Data.Identity.Entitites;
using Cortoxa.Data.Repository;
using Microsoft.AspNet.Identity;

namespace Cortoxa.Data.Identity.Repositories
{
    public class UserStore<TUser, TRole, TClaim> : IUserLoginStore<TUser, Guid>, IUserRoleStore<TUser, Guid>, IUserEmailStore<TUser, Guid>, IUserPasswordStore<TUser, Guid>, IUserClaimStore<TUser, Guid>, IUserSecurityStampStore<TUser, Guid> where TUser : IdentityUser<TRole, TClaim> where TRole : IdentityRole<TUser> where TClaim : IdentityUserClaim<TUser>, new()
    {
        #region Fields

        private bool disposed;
        private readonly IStore<TUser> userRepository;
        private readonly IStore<TRole> roleRepository;
        private readonly IStore<IdentityUserClaim<TUser>> claimsRepository;
//        private readonly IUnitOfWork unitOfWork; 

        #endregion

        #region Constructor

        public UserStore(IStore<TUser> userRepository, IStore<TRole> roleRepository, IStore<IdentityUserClaim<TUser>> claimsRepository)
        {
            this.userRepository = userRepository;
            this.roleRepository = roleRepository;
            this.claimsRepository = claimsRepository;
            AutoSaveChanges = true;
        } 

        #endregion

        #region Properties

        public bool AutoSaveChanges { get; set; }

        #endregion

        #region Claims
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
            user.Claims.Add(new TClaim
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
        #endregion

        #region CRUD

        public async Task CreateAsync(TUser user)
        {
            this.ThrowIfDisposed();
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }
            userRepository.Add(user);
            await userRepository.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task UpdateAsync(TUser user)
        {
            ThrowIfDisposed();
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }
            userRepository.Update(user);
            await userRepository.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task DeleteAsync(TUser user)
        {
            ThrowIfDisposed();
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }
            userRepository.Delete(user);
            await userRepository.SaveChangesAsync().ConfigureAwait(false);
        }

        #endregion

        #region Find By
        public async Task<TUser> FindByIdAsync(Guid userId)
        {
            ThrowIfDisposed();
            return await Task.FromResult(userRepository.Get(userId)).ConfigureAwait(false);
        }

        public async Task<TUser> FindByNameAsync(string userName)
        {
            ThrowIfDisposed();
            userName = userName.ToUpper();
            return await Task.FromResult(userRepository.First(x => x.UserName.ToUpper() == userName)).ConfigureAwait(false);
        } 

        #endregion

        #region User logins

        public Task AddLoginAsync(TUser user, UserLoginInfo login)
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
            //            user.Logins.Add(new IdentityUserLogin
            //            {
            //                User = user,
            //                ProviderKey = login.ProviderKey,
            //                LoginProvider = login.LoginProvider
            //            });
            return Task.FromResult(0);
        }

        public Task RemoveLoginAsync(TUser user, UserLoginInfo login)
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
            return Task.FromResult(0);
        }

        public Task<IList<UserLoginInfo>> GetLoginsAsync(TUser user)
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

        public async Task<TUser> FindAsync(UserLoginInfo login)
        {
            this.ThrowIfDisposed();
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
            return await Task.FromResult(default(TUser)).ConfigureAwait(false);
        }

        #endregion

        #region Roles

        public Task AddToRoleAsync(TUser user, string roleName)
        {
            ThrowIfDisposed();
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }
            roleName = roleName.ToUpper();
            TRole identityRole = roleRepository.Single(r => r.Name.ToUpper() == roleName);
            if (identityRole == null)
            {
                throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, "RoleNotFound {0}", new object[] { roleName }));
            }

            if (user.Roles == null)
            {
                user.Roles = new Collection<TRole>();
            }
            user.Roles.Add(identityRole);
            return Task.FromResult(0);
        }

        public Task RemoveFromRoleAsync(TUser user, string role)
        {
            ThrowIfDisposed();
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }
            role = role.ToUpper();

            var userRole = user.Roles.First(x => x.Name.ToUpper() == role);
            if (userRole != null)
            {
            
                user.Roles.Remove(userRole);
            }
            return Task.FromResult(0);
        }

        public Task<IList<string>> GetRolesAsync(TUser user)
        {
            ThrowIfDisposed();
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }

            List<string> result = user.Roles != null ? user.Roles.Select(x => x.Name).ToList() : new List<string>();

            return Task.FromResult<IList<string>>(result);
        }

        public Task<bool> IsInRoleAsync(TUser user, string roleName)
        {
            ThrowIfDisposed();
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }
            roleName = roleName.ToUpper();
            return Task.FromResult(user.Roles.Any(r => r.Name.ToUpper() == roleName));
        } 

        #endregion

        #region Password

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

        public Task<bool> HasPasswordAsync(TUser user)
        {
            return Task.FromResult(user.PasswordHash != null);
        }

        public Task SetSecurityStampAsync(TUser user, string stamp)
        {
            ThrowIfDisposed();
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }
            user.SecurityStamp = stamp;
            return userRepository.SaveChangesAsync();
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

        #endregion

        #region Email

        public Task SetEmailAsync(TUser user, string email)
        {
            ThrowIfDisposed();
            user.Email = email;
            return userRepository.SaveChangesAsync();
        }

        public Task<string> GetEmailAsync(TUser user)
        {
            ThrowIfDisposed();
            return Task.FromResult(user.Email);
        }

        public Task<bool> GetEmailConfirmedAsync(TUser user)
        {
            ThrowIfDisposed();
            return Task.FromResult(true);
        }

        public Task SetEmailConfirmedAsync(TUser user, bool confirmed)
        {
            ThrowIfDisposed();
            return Task.FromResult(true);
        }

        public async Task<TUser> FindByEmailAsync(string email)
        {
            ThrowIfDisposed();
            email = email.ToLower();
            return await Task.FromResult(userRepository.First(x => x.Email == email)).ConfigureAwait(false);
        }

        #endregion

        #region Disposing 

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            disposed = true;
            /*   session.Dispose();*/
        }

        private void ThrowIfDisposed()
        {
            if (disposed)
            {
                throw new ObjectDisposedException(GetType().Name);
            }
        }

        #endregion

        #region Save changes
        private async Task SaveChanges()
        {
            if (this.AutoSaveChanges)
            {
                await userRepository.SaveChangesAsync().ConfigureAwait(false);
            }
        } 
        #endregion
        
    }
};
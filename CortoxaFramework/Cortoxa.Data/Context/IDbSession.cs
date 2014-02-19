#region Copyright © 2014 Denis Korkhov, Oxagile (http://www.oxagile.com/)
// /*
//  * All rights reserved. This program and the accompanying materials
//  * are made available under the terms of the GNU Lesser General Public License
//  * (LGPL) which accompanies this distribution, and is available at
//  * http://www.gnu.org/licenses/lgpl.html
//  *
//  *  Filename:	IDbSession.cs
//  *  Date:		19/02/2014
//  *  Author:   	Denis Korkhov
//  *
//  */
#endregion

using System;
using System.Linq;

namespace Cortoxa.Data.Context
{
    public interface IDbSession : IUnitOfWork, IDisposable
    {
        IQueryable<TEntity> Query<TEntity>() where TEntity : class, IEntity;

        void Add<TEntity>(TEntity value) where TEntity : class, IEntity;

        void Update<TEntity>(TEntity value) where TEntity : class, IEntity;

        void Delete<TEntity>(TEntity value) where TEntity : class, IEntity; 
    }
}
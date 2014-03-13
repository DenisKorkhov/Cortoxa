#region Copyright © 2014 Denis Korkhov, Oxagile (http://www.oxagile.com/)
// /*
//  * All rights reserved. This program and the accompanying materials
//  * are made available under the terms of the GNU Lesser General Public License
//  * (LGPL) which accompanies this distribution, and is available at
//  * http://www.gnu.org/licenses/lgpl.html
//  *
//  *  Filename:	IStore.cs
//  *  Date:		11/02/2014
//  *  Author:   	Denis Korkhov
//  *
//  */
#endregion

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Cortoxa.Common;
using Cortoxa.Data.Model;

namespace Cortoxa.Data.Repository
{
    public interface IStore<T> : IRepository<T> where T : class, IEntity
    {
        T Get(Guid id);

        T[] Get(params Guid[] id);

        Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> predicate = null);

        Task AddAsync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteAsync(T entity);

        Task<T> GetAsync(Guid id);

        Task<T[]> GetAsync(params Guid[] ids);
    }
}

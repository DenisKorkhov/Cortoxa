#region Copyright © 2014 Denis Korkhov, Oxagile (http://www.oxagile.com/)
// /*
//  * All rights reserved. This program and the accompanying materials
//  * are made available under the terms of the GNU Lesser General Public License
//  * (LGPL) version 2.1 which accompanies this distribution, and is available at
//  * http://www.gnu.org/licenses/lgpl-2.1.html
//  *
//  *  Filename:	IRepository.cs
//  *  Date:		05/02/2014
//  *  Author:   	Denis Korkhov
//  *
//  */
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Cortoxa.Common
{
    public interface IRepository<T> : IDisposable where T : class 
    {
        IQueryable<T> GetQuery();

        T First(Expression<Func<T, bool>> predicate);

//        Task<T> FirstAsync(Expression<Func<T, bool>> predicate);

        T Single(Expression<Func<T, bool>> predicate);

//        Task<T> SingleAsync(Expression<Func<T, bool>> predicate);

        IEnumerable<T> FindAll(Expression<Func<T, bool>> predicate = null);

//        Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> predicate = null);

        void Add(T entity);

//        Task AddAsync(T entity);

        void Update(T entity);

//        Task UpdateAsync(T entity);

        void Delete(T entity);

//        Task DeleteAsync(T entity);
    }
}
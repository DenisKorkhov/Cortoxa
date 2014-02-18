#region Copyright © 2014 Denis Korkhov, Oxagile (http://www.oxagile.com/)
// /*
//  * All rights reserved. This program and the accompanying materials
//  * are made available under the terms of the GNU Lesser General Public License
//  * (LGPL) version 2.1 which accompanies this distribution, and is available at
//  * http://www.gnu.org/licenses/lgpl-2.1.html
//  *
//  *  Filename:	IStore.cs
//  *  Date:		11/02/2014
//  *  Author:   	Denis Korkhov
//  *
//  */
#endregion
using System;
using System.Threading.Tasks;
using Cortoxa.Common;

namespace Cortoxa.Data.Repository
{
    public interface IStore<T> : IRepository<T> where T : class
    {
        T Get(Guid id);

        Task<T> GetAsync(Guid id);

        T[] Get(params Guid[] id);

        Task<T[]> GetAsync(params Guid[] id);
    }
}

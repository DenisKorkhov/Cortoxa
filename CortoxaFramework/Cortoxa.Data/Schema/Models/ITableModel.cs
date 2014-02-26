#region Copyright © 2014 Denis Korkhov, Oxagile (http://www.oxagile.com/)
// /*
//  * All rights reserved. This program and the accompanying materials
//  * are made available under the terms of the GNU Lesser General Public License
//  * (LGPL) which accompanies this distribution, and is available at
//  * http://www.gnu.org/licenses/lgpl.html
//  *
//  *  Filename:	ITableModel.cs
//  *  Date:		18/02/2014
//  *  Author:   	Denis Korkhov
//  *
//  */
#endregion
using System;
using System.Linq.Expressions;
using Cortoxa.Data.Common;
using Cortoxa.Data.Model;

namespace Cortoxa.Data.Schema.Models
{
    public interface ITableModel<T> where T : IEntity
    {

        ITableModel<T> Id(Expression<Func<T, object>> identityField);

        ITableModel<T> Id(Expression<Func<T, object>> identityField, string name);

        ITableModel<T> Id(Expression<Func<T, object>> identityField, Action<IIdentityModel<T>> property);

        ITableModel<T> Property(Expression<Func<T, object>> identityField);

        ITableModel<T> Property(Expression<Func<T, object>> identityField, string name);

        ITableModel<T> Property(Expression<Func<T, object>> identityField, Action<IPropertyModel<T>> property);

        ITableModel<T> OneToMany(Expression<Func<T, object>> identityField, Action<IOneToManyModel<T>> property);

        ITableModel<T> ManyToMany(Expression<Func<T, object>> identityField, Action<IManyToManyModel<T>> property);
    }
}
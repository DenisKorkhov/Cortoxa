#region Copyright © 2014 Denis Korkhov, Oxagile (http://www.oxagile.com/)
// /*
//  * All rights reserved. This program and the accompanying materials
//  * are made available under the terms of the GNU Lesser General Public License
//  * (LGPL) version 2.1 which accompanies this distribution, and is available at
//  * http://www.gnu.org/licenses/lgpl-2.1.html
//  *
//  *  Filename:	HibernateModelBuilder.cs
//  *  Date:		18/02/2014
//  *  Author:   	Denis Korkhov
//  *
//  */
#endregion
using System;
using Cortoxa.Data;
using Cortoxa.Data.Schema;
using Cortoxa.Data.Schema.Models;

namespace Cortoxa.NHibernate.Schema
{
    public class HibernateModelBuilder :  IModelBuilder
    {
        public ITableModel<T> ForEntity<T>() where T : IEntity
        {
            throw new NotImplementedException();
        }

        public ITableModel<T> ForEntity<T>(string tableName) where T : IEntity
        {
            throw new NotImplementedException();
        }

        public ITableModel<T> ForEntity<T>(Type type, string tableName) where T : IEntity
        {
            throw new NotImplementedException();
        }
        public void Build()
        {
            throw new NotImplementedException();
        }
    }
}
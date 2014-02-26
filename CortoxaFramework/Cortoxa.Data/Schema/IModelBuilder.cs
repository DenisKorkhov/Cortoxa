#region Copyright © 2014 Denis Korkhov, Oxagile (http://www.oxagile.com/)
// /*
//  * All rights reserved. This program and the accompanying materials
//  * are made available under the terms of the GNU Lesser General Public License
//  * (LGPL) which accompanies this distribution, and is available at
//  * http://www.gnu.org/licenses/lgpl.html
//  *
//  *  Filename:	IModelBuilder.cs
//  *  Date:		18/02/2014
//  *  Author:   	Denis Korkhov
//  *
//  */
#endregion
using System;
using Cortoxa.Data.Common;
using Cortoxa.Data.Model;
using Cortoxa.Data.Schema.Models;

namespace Cortoxa.Data.Schema
{
    public interface IModelBuilder
    {
        ITableModel<T> ForEntity<T>() where T : IEntity;

        ITableModel<T> ForEntity<T>(string tableName) where T : IEntity;

        ITableModel<T> ForEntity<T>(Type type, string tableName) where T : IEntity;

        void Build(/*T builder*/);
    }
}
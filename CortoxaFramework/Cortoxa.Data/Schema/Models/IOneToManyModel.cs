#region Copyright © 2014 
// /*
//  * All rights reserved. This program and the accompanying materials
//  * are made available under the terms of the GNU Lesser General Public License
//  * (LGPL) which accompanies this distribution, and is available at
//  * http://www.gnu.org/licenses/lgpl.html
//  *
//  *  Filename:	IOneToManyModel.cs
//  *  Date:		18/02/2014
//  *  Author:   	Denis Korkhov
//  *
//  */
#endregion

using Cortoxa.Data.Common;
using Cortoxa.Data.Model;

namespace Cortoxa.Data.Schema.Models
{
    public interface IOneToManyModel<T> where T : IEntity
    {
    }
}
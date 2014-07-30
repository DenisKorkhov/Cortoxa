#region Copyright © 2014 
// /*
//  * All rights reserved. This program and the accompanying materials
//  * are made available under the terms of the GNU Lesser General Public License
//  * (LGPL) which accompanies this distribution, and is available at
//  * http://www.gnu.org/licenses/lgpl.html
//  *
//  *  Filename:	IConnectionBuilder.cs
//  *  Date:		19/02/2014
//  *  Author:   	Denis Korkhov
//  *
//  */
#endregion

using NHibernate;

namespace Cortoxa.Data.NHibernate.Data
{
    public interface IConnectionBuilder
    {
        ISessionFactory BuildFactory();
    }
}
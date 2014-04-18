#region Copyright © 2014 Denis Korkhov, Oxagile (http://www.oxagile.com/)
// /*
//  * All rights reserved. This program and the accompanying materials
//  * are made available under the terms of the GNU Lesser General Public License
//  * (LGPL) which accompanies this distribution, and is available at
//  * http://www.gnu.org/licenses/lgpl.html
//  *
//  *  Filename:	EntityModelFactory.cs
//  *  Date:		19/02/2014
//  *  Author:   	Denis Korkhov
//  *
//  */
#endregion

using System.Data.Entity;
using Cortoxa.Data.Context;

namespace Cortoxa.Data.EntityFramework.Context
{
    public class EntityModelFactory :  IModelFactory<DbContext>
    {
        public virtual void Configure()
        {
            //Do nothing
        }

        public DbContext GetSession()
        {
            //return this;
            return null;
        }


        public virtual void BuildModel()
        {

        }
    }
}
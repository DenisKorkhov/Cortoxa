#region Copyright © 2014 Denis Korkhov, Oxagile (http://www.oxagile.com/)
// /*
//  * All rights reserved. This program and the accompanying materials
//  * are made available under the terms of the GNU Lesser General Public License
//  * (LGPL) which accompanies this distribution, and is available at
//  * http://www.gnu.org/licenses/lgpl.html
//  *
//  *  Filename:	BaseServiceBuilder.cs
//  *  Date:		24/02/2014
//  *  Author:   	Denis Korkhov
//  *
//  */
#endregion

using System;
using Cortoxa.IoC2.Base;

namespace Cortoxa.IoC2.Service
{
    public abstract class BaseServiceBuilder : IServiceBuilder
    {
        private readonly RegistrationContext context = new RegistrationContext();

        public abstract IToolContainer2 Done();

        public virtual IServiceBuilder To<T>()
        {
            return this.To(typeof (T));
        }

        public virtual IServiceBuilder To(Type type)
        {
            context.To = type;
            return this;
        }

        public virtual IServiceBuilder ToSelf()
        {
            return this.To(Context.For);
        }

        public virtual IServiceBuilder Name(string name)
        {
            context.Name = name;
            return this;
        }

        public virtual RegistrationContext Context
        {
            get { return context; }
        }
    }
}
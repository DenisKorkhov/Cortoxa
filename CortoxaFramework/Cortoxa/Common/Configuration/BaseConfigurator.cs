#region Copyright © 2014 Denis Korkhov, Oxagile (http://www.oxagile.com/)
// 
// // /*
// //  * All rights reserved. This program and the accompanying materials
// //  * are made available under the terms of the GNU Lesser General Public License
// //  * (LGPL) version 2.1 which accompanies this distribution, and is available at
// //  * http://www.gnu.org/licenses/lgpl-2.1.html
// //  *
// //  *  Filename:	BaseConfigurator.cs
// //  *  Date:		11/03/2014
// //  *  Author:   	Denis Korkhov
// //  *
// //  */
#endregion
using System.Runtime.InteropServices;

namespace Cortoxa.Common.Configuration
{
    public abstract class BaseConfigurator<T> : IConfigurator<T>
    {
        private readonly IConfigurationStrategy<T> strategy;
        private readonly T context;

        protected BaseConfigurator(IConfigurationStrategy<T> strategy, T context)
        {
            this.strategy = strategy;
            this.context = context;
        }

        public T Context
        {
            get { return context; }
        }

        public void Configure()
        {
            strategy.Configure(Context);
        }
    }
}
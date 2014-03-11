#region Copyright © 2014 Denis Korkhov, Oxagile (http://www.oxagile.com/)
// 
// // /*
// //  * All rights reserved. This program and the accompanying materials
// //  * are made available under the terms of the GNU Lesser General Public License
// //  * (LGPL) version 2.1 which accompanies this distribution, and is available at
// //  * http://www.gnu.org/licenses/lgpl-2.1.html
// //  *
// //  *  Filename:	ToolSetup.cs
// //  *  Date:		11/03/2014
// //  *  Author:   	Denis Korkhov
// //  *
// //  */
#endregion
using System;
using Cortoxa.Container.Common;

namespace Cortoxa.Container
{
    public class ToolSetup<T> : ISetupBuilder<T>, ISetupConfigurator<T> 
    {
        protected T Value;

        public void Create(Func<T> action)
        {
            Value = action();
        }

        public void Configure(Action<T> action)
        {
            action(Value);
        }

        public T Build()
        {
            return Value;
        }
    }
}
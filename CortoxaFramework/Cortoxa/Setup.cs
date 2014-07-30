#region Copyright © 2014 
// 
// // /*
// //  * All rights reserved. This program and the accompanying materials
// //  * are made available under the terms of the GNU Lesser General Public License
// //  * (LGPL) version 2.1 which accompanies this distribution, and is available at
// //  * http://www.gnu.org/licenses/lgpl-2.1.html
// //  *
// //  *  Filename:	Setup.cs
// //  *  Date:		11/03/2014
// //  *  Author:   	Denis Korkhov
// //  *
// //  */
#endregion
using System;
using Cortoxa.Configuration;
using Cortoxa.Container;

namespace Cortoxa
{
    public static class Setup
    {
        public static IToolContainer Container(Action<IConfigurator<IToolContainer>> setupAction)
        {
            var configurator = new Configurator<IToolContainer>();
            setupAction(configurator);
            return configurator.Build();
        }
    }
}
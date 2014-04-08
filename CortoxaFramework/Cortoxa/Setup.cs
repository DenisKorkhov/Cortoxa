#region Copyright © 2014 Denis Korkhov, Oxagile (http://www.oxagile.com/)
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
using Cortoxa.Container;

namespace Cortoxa
{
    public static class Setup
    {
        public static IToolContainer Container(Action<Action<IToolContainer>> setupAction)
        {
            IToolContainer result = null;

            setupAction(c => { result = c; });
            return result;

//            var result = setupAction(c => c);
////            result();
////            setupAction(c => result = c);
//            return result;
        }
    }
}
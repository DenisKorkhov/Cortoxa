#region Copyright © 2014 Denis Korkhov, Oxagile (http://www.oxagile.com/)
// /*
//  * All rights reserved. This program and the accompanying materials
//  * are made available under the terms of the GNU Lesser General Public License
//  * (LGPL) version 2.1 which accompanies this distribution, and is available at
//  * http://www.gnu.org/licenses/lgpl-2.1.html
//  *
//  *  Filename:	Setup.cs
//  *  Date:		07/02/2014
//  *  Author:   	Denis Korkhov
//  *
//  */
#endregion
using System;
using Cortoxa.IoC;

namespace Cortoxa
{
    public static class Setup
    {
        public static IToolContainer InitContainer(Func<IToolSetup, IToolContainer> setupAction)
        {
            var container = setupAction(null);
            return container;
        }
    }

    public interface IToolSetup
    {
        string Name { get; set; }
    }
}
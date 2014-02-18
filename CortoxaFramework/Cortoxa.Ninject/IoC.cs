#region Copyright © 2014 Denis Korkhov, Oxagile (http://www.oxagile.com/)
// /*
//  * All rights reserved. This program and the accompanying materials
//  * are made available under the terms of the GNU Lesser General Public License
//  * (LGPL) version 2.1 which accompanies this distribution, and is available at
//  * http://www.gnu.org/licenses/lgpl-2.1.html
//  *
//  *  Filename:	IoC.cs
//  *  Date:		04/02/2014
//  *  Author:   	Denis Korkhov
//  *
//  */
#endregion
using Cortoxa.IoC;
using Ninject;

namespace Cortoxa.Ninject
{
    public class IoC
    {
        public static IToolContainer UseNinject()
        {
            return new NinjectContainer(new StandardKernel());
        }

        public static IToolContainer UseNinject(IKernel container)
        {
            return new NinjectContainer(container);
        }
    }
}
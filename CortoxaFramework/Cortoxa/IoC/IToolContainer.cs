#region Copyright © 2014 Denis Korkhov, Oxagile (http://www.oxagile.com/)

// /*
//  * All rights reserved. This program and the accompanying materials
//  * are made available under the terms of the GNU Lesser General Public License
//  * (LGPL) which accompanies this distribution, and is available at
//  * http://www.gnu.org/licenses/lgpl.html
//  *
//  *  Filename:	IToolContainer.cs
//  *  Date:		21/02/2014
//  *  Author:   	Denis Korkhov
//  *
//  */

#endregion

using Cortoxa.IoC.Base;

namespace Cortoxa.IoC
{
    public interface IToolContainer
    {
//        IToolRegistrator Register { get; }

//        IToolContainer Register(Action<IServiceBuilderFor> serviceAction);
//
//        IToolContainer Register<T>(Action<IToolComponent<T>> componentAction) where T : class, new ();

        IToolRegistrator Register { get; }

        IToolResolver Resolve { get; }
    }
}
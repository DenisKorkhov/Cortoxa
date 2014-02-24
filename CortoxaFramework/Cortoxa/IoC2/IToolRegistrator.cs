#region Copyright © 2014 Denis Korkhov, Oxagile (http://www.oxagile.com/)
// /*
//  * All rights reserved. This program and the accompanying materials
//  * are made available under the terms of the GNU Lesser General Public License
//  * (LGPL) which accompanies this distribution, and is available at
//  * http://www.gnu.org/licenses/lgpl.html
//  *
//  *  Filename:	IToolRegistrator.cs
//  *  Date:		21/02/2014
//  *  Author:   	Denis Korkhov
//  *
//  */
#endregion

using System;
using Cortoxa.IoC2.Base;
using Cortoxa.IoC2.Fluent;
using Cortoxa.IoC2.Service;

namespace Cortoxa.IoC2
{
    public interface IToolRegistrator
    {
        IToolRegistrator Service<T>(Action<IServiceBuilder> service);

        IToolRegistrator Service(Type type, Action<IServiceBuilder> service);
        
//        IToolContainer2 Component(IToolComponent component);
    }
}
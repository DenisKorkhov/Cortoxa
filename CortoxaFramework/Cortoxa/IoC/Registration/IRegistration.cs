#region Copyright © 2014 Denis Korkhov, Oxagile (http://www.oxagile.com/)
// /*
//  * All rights reserved. This program and the accompanying materials
//  * are made available under the terms of the GNU Lesser General Public License
//  * (LGPL) version 2.1 which accompanies this distribution, and is available at
//  * http://www.gnu.org/licenses/lgpl-2.1.html
//  *
//  *  Filename:	IRegistration.cs
//  *  Date:		05/02/2014
//  *  Author:   	Denis Korkhov
//  *
//  */
#endregion
using Cortoxa.IoC.Attributes;

namespace Cortoxa.IoC.Registration
{
    public interface IRegistration
    {
        IToolRegistration LifeTime(ToolkitLifeTime lifeTime);

        TypeContext Context { get; }
    }
}
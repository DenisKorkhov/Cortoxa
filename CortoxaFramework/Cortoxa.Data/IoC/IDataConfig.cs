#region Copyright © 2014 Denis Korkhov, Oxagile (http://www.oxagile.com/)
// /*
//  * All rights reserved. This program and the accompanying materials
//  * are made available under the terms of the GNU Lesser General Public License
//  * (LGPL) which accompanies this distribution, and is available at
//  * http://www.gnu.org/licenses/lgpl.html
//  *
//  *  Filename:	IDataConfig.cs
//  *  Date:		17/02/2014
//  *  Author:   	Denis Korkhov
//  *
//  */
#endregion
using Cortoxa.Initialization;
using Cortoxa.IoC.Base;

namespace Cortoxa.Data.IoC
{
    public interface IDataConfig : IRegistrationConfig
    {
        IDataConfig WithSession<T>(LifeTime lifeTime = LifeTime.Transient);
    }
}
#region Copyright © 2014 Denis Korkhov, Oxagile (http://www.oxagile.com/)

// /*
//  * All rights reserved. This program and the accompanying materials
//  * are made available under the terms of the GNU Lesser General Public License
//  * (LGPL) which accompanies this distribution, and is available at
//  * http://www.gnu.org/licenses/lgpl.html
//  *
//  *  Filename:	IServiceBuilder.cs
//  *  Date:		21/02/2014
//  *  Author:   	Denis Korkhov
//  *
//  */

#endregion

namespace Cortoxa.IoC.Base.ServiceFamily
{
    public interface IServiceBuilder : IServiceBuilderFor, IServiceBuilderTo, IServiceBuilderRest, IRegistrationStratagy
    {

    
    }
}
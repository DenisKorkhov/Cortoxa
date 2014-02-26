#region Copyright © 2014 Denis Korkhov, Oxagile (http://www.oxagile.com/)

// /*
//  * All rights reserved. This program and the accompanying materials
//  * are made available under the terms of the GNU Lesser General Public License
//  * (LGPL) which accompanies this distribution, and is available at
//  * http://www.gnu.org/licenses/lgpl.html
//  *
//  *  Filename:	IToolResolver.cs
//  *  Date:		21/02/2014
//  *  Author:   	Denis Korkhov
//  *
//  */

#endregion

using System;

namespace Cortoxa.IoC.Base
{
    public interface IToolResolver
    {
        T One<T>(object arguments = null);

        object One(Type type, object arguments = null);

        T One<T>(Type type, object arguments = null);

        T One<T>(string key, object arguments = null);

        T[] All<T>(object arguments = null);

        object[] All(Type type, object arguments = null);

        T[] All<T>(Type type, object arguments = null);

        void Release(Type type);

        void Release(object instance);
    }
}
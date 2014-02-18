#region Copyright © 2014 Denis Korkhov, Oxagile (http://www.oxagile.com/)
// /*
//  * All rights reserved. This program and the accompanying materials
//  * are made available under the terms of the GNU Lesser General Public License
//  * (LGPL) version 2.1 which accompanies this distribution, and is available at
//  * http://www.gnu.org/licenses/lgpl-2.1.html
//  *
//  *  Filename:	MethodInteception.cs
//  *  Date:		05/02/2014
//  *  Author:   	Denis Korkhov
//  *
//  */
#endregion
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Cortoxa.IoC.Interception
{
    public class MethodInteception
    {
        #region Fields

        private readonly Delegate action;

        private readonly MethodInteceptionType mode;

        private readonly MethodInfo method; 

        #endregion

        public MethodInteception(Delegate action, MethodInteceptionType mode) : this(action, mode, null)
        {
        }

        public MethodInteception(Delegate action, MethodInteceptionType mode, MethodInfo method)
        {
            this.action = action;
            this.mode = mode;
            this.method = method;
        }

        public MethodInfo Method
        {
            get { return method; }
        }

        public Delegate Action
        {
            get { return action; }
        }

        public MethodInteceptionType Mode
        {
            get { return mode; }
        }
    }

    public enum MethodInteceptionType
    {
        Before,
        Replace,
        After,
        Process
    }
}
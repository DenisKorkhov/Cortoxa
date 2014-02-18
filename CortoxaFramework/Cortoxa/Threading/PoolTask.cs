#region Copyright © 2014 Denis Korkhov, Oxagile (http://www.oxagile.com/)
// /*
//  * All rights reserved. This program and the accompanying materials
//  * are made available under the terms of the GNU Lesser General Public License
//  * (LGPL) version 2.1 which accompanies this distribution, and is available at
//  * http://www.gnu.org/licenses/lgpl-2.1.html
//  *
//  *  Filename:	PoolTask.cs
//  *  Date:		05/02/2014
//  *  Author:   	Denis Korkhov
//  *
//  */
#endregion
using System;

namespace Cortoxa.Threading
{
    public class PoolTask
    {
        private readonly Action<Exception> onFinish;

        public PoolTask(Delegate action, Action<Exception> onFinish = null)
        {
            this.onFinish = onFinish;
            this.Action = action;
        }

        public Delegate Action { get; set; }

        public Action<Exception> OnFinish
        {
            get { return onFinish; }
        }
    }
}
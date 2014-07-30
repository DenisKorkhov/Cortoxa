#region Copyright © 2014 
// /*
//  * All rights reserved. This program and the accompanying materials
//  * are made available under the terms of the GNU Lesser General Public License
//  * (LGPL) which accompanies this distribution, and is available at
//  * http://www.gnu.org/licenses/lgpl.html
//  *
//  *  Filename:	StingExtentions.cs
//  *  Date:		19/02/2014
//  *  Author:   	Denis Korkhov
//  *
//  */
#endregion
namespace Cortoxa.Common
{
    public static class StingExtentions
    {
        public static string Format(this string value, params object[] args)
        {
            return string.Format(value, args);
        }
    }
}
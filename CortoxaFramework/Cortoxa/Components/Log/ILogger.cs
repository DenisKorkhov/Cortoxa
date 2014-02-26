#region Copyright © 2014 Denis Korkhov, Oxagile (http://www.oxagile.com/)
// /*
//  * All rights reserved. This program and the accompanying materials
//  * are made available under the terms of the GNU Lesser General Public License
//  * (LGPL) version 2.1 which accompanies this distribution, and is available at
//  * http://www.gnu.org/licenses/lgpl-2.1.html
//  *
//  *  Filename:	ILogger.cs
//  *  Date:		05/02/2014
//  *  Author:   	Denis Korkhov
//  *
//  */
#endregion

using System;

namespace Cortoxa.Components.Log
{
    public interface ILogger
    {
        void Error(string message);

        void Error(string message, params string[] formattingParams);

        void Error(string message, Exception exception);

        void Info(string message);

        void Info(string message, params object[] formattingParams);

        void Warn(string message);

        void Warn(string message, params string[] formattingParams);

        void Debug(string message);

        void Debug(string message, params string[] formattingParams);

        void Trace(string message);

        void Trace(string message, params string[] formattingParams);

    }
}
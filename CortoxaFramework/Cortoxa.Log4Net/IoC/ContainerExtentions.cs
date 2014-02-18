#region Copyright © 2014 Denis Korkhov, Oxagile (http://www.oxagile.com/)
// /*
//  * All rights reserved. This program and the accompanying materials
//  * are made available under the terms of the GNU Lesser General Public License
//  * (LGPL) version 2.1 which accompanies this distribution, and is available at
//  * http://www.gnu.org/licenses/lgpl-2.1.html
//  *
//  *  Filename:	ContainerExtentions.cs
//  *  Date:		04/02/2014
//  *  Author:   	Denis Korkhov
//  *
//  */
#endregion
using System;
using Cortoxa.Common.Log;
using Cortoxa.IoC;
using Cortoxa.IoC.Registration.Extentions;
using log4net;

namespace Cortoxa.Log4Net.IoC
{
    public static class ContainerExtentions
    {
        public static IToolContainer InstallLog4Net(this IToolContainer container, string configFile, string loggerName)
        {

            container.Register(r => r.For<ILogger>()
                .InterceptMethod<ILogger>(t => t.Debug(""), (c, o) => { GetLogger(loggerName).Debug(o.Arguments[0] as string); return null; })
                .InterceptMethod<ILogger>(t => t.Info(""), (c, o) => { GetLogger(loggerName).Info(o.Arguments[0] as string); return null; })
                .InterceptMethod<ILogger>(t => t.Info("", null), (c, o) => { GetLogger(loggerName).Info(string.Format((string)o.Arguments[0], o.Arguments[0])); return null; })
                .InterceptMethod<ILogger>(t => t.Error(""), (c, o) => { GetLogger(loggerName).Error(o.Arguments[0] as string); return null; })
                .InterceptMethod<ILogger>(t => t.Error("", default(Exception)), (c, o) => { GetLogger(loggerName).Error(o.Arguments[0] as string, o.Arguments[1] as Exception); return null; })
                .InterceptMethod<ILogger>(t => t.Trace(""), (c, o) => { GetLogger(loggerName).Debug(o.Arguments[0] as string); return null; })
                .InterceptMethod<ILogger>(t => t.Warn(""), (c, o) => { GetLogger(loggerName).Warn(o.Arguments[0] as string); return null; })
                );
            return container;
        }

        private static ILog GetLogger(string loggerName)
        {
            var logger = LogManager.GetLogger(loggerName);
            return logger;
        }
    }
}


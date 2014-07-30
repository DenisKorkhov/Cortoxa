#region Copyright © 2014 
// 
// // /*
// //  * All rights reserved. This program and the accompanying materials
// //  * are made available under the terms of the GNU Lesser General Public License
// //  * (LGPL) version 2.1 which accompanies this distribution, and is available at
// //  * http://www.gnu.org/licenses/lgpl-2.1.html
// //  *
// //  *  Filename:	NLogSetup.cs
// //  *  Date:		11/03/2014
// //  *  Author:   	Denis Korkhov
// //  *
// //  */
#endregion

using System;
using Cortoxa.Common.Log;
using Cortoxa.Container.Component;
using Cortoxa.Container.Component.Logging;
using Cortoxa.Container.Extentions;
using Cortoxa.Container.Registrator;
using NLog;

namespace Cortoxa.NLogger
{

    public static class NLogSetup
    {
        public static IComponentConfigurator<LoggerContext> NLog(this IRegistration registration)
        {
            var configurator = new ComponentConfigurator<LoggerContext>(registration);
            configurator.Register((r, c) => r.For<ILogger>()
                .Intercept.Method<ILogger>(m => m.Info(default(string)), context => GetLogger(context.ResolverType.FullName).Info(context.Arguments[0] as string))
                .Intercept.Method<ILogger>(m => m.Trace(default(string)), context => GetLogger(context.ResolverType.FullName).Trace(context.Arguments[0] as string))
                .Intercept.Method<ILogger>(m => m.Warn(default(string)), context => GetLogger(context.ResolverType.FullName).Warn(context.Arguments[0] as string))
                .Intercept.Method<ILogger>(m => m.Debug(default(string)), context => GetLogger(context.ResolverType.FullName).Debug(context.Arguments[0] as string))
                .Intercept.Method<ILogger>(m => m.Error(default(string)), context => GetLogger(context.ResolverType.FullName).Error(context.Arguments[0] as string))
                .Intercept.Method<ILogger>(m => m.Info(default(string), default(string[])), context => GetLogger(context.ResolverType.FullName).Info(context.Arguments[0] as string, context.Arguments[1] as object[]))
                .Intercept.Method<ILogger>(m => m.Trace(default(string), default(string[])), context => GetLogger(context.ResolverType.FullName).Trace(context.Arguments[0] as string, context.Arguments[1] as object[]))
                .Intercept.Method<ILogger>(m => m.Warn(default(string), default(string[])), context => GetLogger(context.ResolverType.FullName).Warn(context.Arguments[0] as string, context.Arguments[1] as object[]))
                .Intercept.Method<ILogger>(m => m.Debug(default(string), default(string[])), context => GetLogger(context.ResolverType.FullName).Debug(context.Arguments[0] as string, context.Arguments[1] as object[]))
                .Intercept.Method<ILogger>(m => m.Error(default(string), default(string[])), context => GetLogger(context.ResolverType.FullName).Error(context.Arguments[0] as string, context.Arguments[1] as object[]))
                .Intercept.Method<ILogger>(m => m.Error(default(string), default(Exception)), context => GetLogger(context.ResolverType.FullName).ErrorException(context.Arguments[0] as string, context.Arguments[1] as Exception)));
            return configurator;
        }

        private static Logger GetLogger(string name)
        {
            return LogManager.GetLogger(name);
        }
    }
}
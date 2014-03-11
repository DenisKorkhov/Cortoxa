#region Copyright © 2014 Denis Korkhov, Oxagile (http://www.oxagile.com/)
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
using Cortoxa.Common;
using Cortoxa.Container.Components;
using Cortoxa.Container.Services;
using NLog;

namespace Cortoxa.NLog
{
    public static class NLogSetup
    {
        public static IComponentConfigurator<LoggerComponent> Nlog(this IComponentRegistrator componentRegistrator)
        {
            return componentRegistrator.Configure<LoggerComponent>(c=>c.Logger, r=>r.For<ILogger>()
                .Intercept.Method<ILogger>(m => m.Info(default(string)), context => GetLogger(context.ResolverType.FullName).Info(context.Arguments[0] as string))
                .Intercept.Method<ILogger>(m => m.Trace(default(string)), context => GetLogger(context.ResolverType.FullName).Info(context.Arguments[0] as string))
                .Intercept.Method<ILogger>(m => m.Warn(default(string)), context => GetLogger(context.ResolverType.FullName).Info(context.Arguments[0] as string))
                .Intercept.Method<ILogger>(m => m.Debug(default(string)), context => GetLogger(context.ResolverType.FullName).Info(context.Arguments[0] as string))
                .Intercept.Method<ILogger>(m => m.Error(default(string)), context => GetLogger(context.ResolverType.FullName).Info(context.Arguments[0] as string))
                .Intercept.Method<ILogger>(m => m.Info(default(string), default(string[])), context => GetLogger(context.ResolverType.FullName).Info(context.Arguments[0] as string, context.Arguments[1] as object[]))
                .Intercept.Method<ILogger>(m => m.Trace(default(string), default(string[])), context => GetLogger(context.ResolverType.FullName).Trace(context.Arguments[0] as string, context.Arguments[1] as object[]))
                .Intercept.Method<ILogger>(m => m.Warn(default(string), default(string[])), context => GetLogger(context.ResolverType.FullName).Warn(context.Arguments[0] as string, context.Arguments[1] as object[]))
                .Intercept.Method<ILogger>(m => m.Debug(default(string), default(string[])), context => GetLogger(context.ResolverType.FullName).Debug(context.Arguments[0] as string, context.Arguments[1] as object[]))
                .Intercept.Method<ILogger>(m => m.Error(default(string), default(string[])), context => GetLogger(context.ResolverType.FullName).Error(context.Arguments[0] as string, context.Arguments[1] as object[]))
                .Intercept.Method<ILogger>(m => m.Error(default(string), default(Exception)), context => GetLogger(context.ResolverType.FullName).ErrorException(context.Arguments[0] as string, context.Arguments[1] as Exception)));
        }

        private static Logger GetLogger(string name)
        {
            return LogManager.GetLogger(name);
        }
    }
}
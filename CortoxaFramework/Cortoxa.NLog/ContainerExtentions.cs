#region Copyright © 2014 Denis Korkhov, Oxagile (http://www.oxagile.com/)
// /*
//  * All rights reserved. This program and the accompanying materials
//  * are made available under the terms of the GNU Lesser General Public License
//  * (LGPL) version 2.1 which accompanies this distribution, and is available at
//  * http://www.gnu.org/licenses/lgpl-2.1.html
//  *
//  *  Filename:	ContainerExtentions.cs
//  *  Date:		07/02/2014
//  *  Author:   	Denis Korkhov
//  *
//  */
#endregion
using System;
using Cortoxa.Common.Log;
using Cortoxa.IoC;
using Cortoxa.IoC.Attributes;
using Cortoxa.IoC.Registration.Extentions;
using NLog;

namespace Cortoxa.NLog
{
    public static class ContainerExtentions
    {
        public static IToolContainer InstallNLog(this IToolContainer container, string loggetName)
        {
            return container.Register(r => r.For<ILogger>()
                .InterceptMethod<ILogger>((m) => m.Info(default(string)), (cnt, context) => GetLogger(context.ResolverType.FullName).Info(context.Arguments[0] as string))
                .InterceptMethod<ILogger>((m) => m.Trace(default(string)), (cnt, context) => GetLogger(context.ResolverType.FullName).Info(context.Arguments[0] as string))
                .InterceptMethod<ILogger>((m) => m.Warn(default(string)), (cnt, context) => GetLogger(context.ResolverType.FullName).Info(context.Arguments[0] as string))
                .InterceptMethod<ILogger>((m) => m.Debug(default(string)), (cnt, context) => GetLogger(context.ResolverType.FullName).Info(context.Arguments[0] as string))
                .InterceptMethod<ILogger>((m) => m.Error(default(string)), (cnt, context) => GetLogger(context.ResolverType.FullName).Info(context.Arguments[0] as string))

                .InterceptMethod<ILogger>((m) => m.Info(default(string), default(string[])), (cnt, context) => GetLogger(context.ResolverType.FullName).Info(context.Arguments[0] as string, context.Arguments[1] as object[]))
                .InterceptMethod<ILogger>((m) => m.Trace(default(string), default(string[])), (cnt, context) => GetLogger(context.ResolverType.FullName).Trace(context.Arguments[0] as string, context.Arguments[1] as object[]))
                .InterceptMethod<ILogger>((m) => m.Warn(default(string), default(string[])), (cnt, context) => GetLogger(context.ResolverType.FullName).Warn(context.Arguments[0] as string, context.Arguments[1] as object[]))
                .InterceptMethod<ILogger>((m) => m.Debug(default(string), default(string[])), (cnt, context) => GetLogger(context.ResolverType.FullName).Debug(context.Arguments[0] as string, context.Arguments[1] as object[]))
                .InterceptMethod<ILogger>((m) => m.Error(default(string), default(string[])), (cnt, context) => GetLogger(context.ResolverType.FullName).Error(context.Arguments[0] as string, context.Arguments[1] as object[]))
                .InterceptMethod<ILogger>((m) => m.Error(default(string), default(Exception)), (cnt, context) => GetLogger(context.ResolverType.FullName).ErrorException(context.Arguments[0] as string, context.Arguments[1] as Exception))
            );
        }

        private static Logger GetLogger(string name)
        {
            return LogManager.GetLogger(name);
        }
    }
}
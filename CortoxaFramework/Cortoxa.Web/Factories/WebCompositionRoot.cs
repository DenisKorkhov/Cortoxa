﻿#region Copyright © 2014 
// /*
//  * All rights reserved. This program and the accompanying materials
//  * are made available under the terms of the GNU Lesser General Public License
//  * (LGPL) version 2.1 which accompanies this distribution, and is available at
//  * http://www.gnu.org/licenses/lgpl-2.1.html
//  *
//  *  Filename:	WebCompositionRoot.cs
//  *  Date:		04/02/2014
//  *  Author:   	Denis Korkhov
//  *
//  */
#endregion
using System;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;
using Cortoxa.Container;
using Cortoxa.Container.Registrator;

namespace Cortoxa.Web.Factories
{
    public class WebCompositionRoot : IHttpControllerActivator
    {
        private readonly IToolContainer container;

        public WebCompositionRoot(IToolContainer container)
        {
            this.container = container;
        }

        public IHttpController Create(HttpRequestMessage request, HttpControllerDescriptor controllerDescriptor, Type controllerType)
        {
            var controller = (IHttpController)container.Resolver.Resolve(controllerType);
            request.RegisterForDispose(new Release(() => container.Release(controller)));
            return controller;
        }

        private class Release : IDisposable
        {
            private readonly Action release;

            public Release(Action release)
            {
                this.release = release;
            }

            public void Dispose()
            {
                release();
            }
        }
    }
}
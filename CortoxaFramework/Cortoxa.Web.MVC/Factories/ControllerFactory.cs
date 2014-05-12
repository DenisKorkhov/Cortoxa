#region Copyright © 2014 Denis Korkhov, Oxagile (http://www.oxagile.com/)
// /*
//  * All rights reserved. This program and the accompanying materials
//  * are made available under the terms of the GNU Lesser General Public License
//  * (LGPL) version 2.1 which accompanies this distribution, and is available at
//  * http://www.gnu.org/licenses/lgpl-2.1.html
//  *
//  *  Filename:	ControllerFactory.cs
//  *  Date:		17/02/2014
//  *  Author:   	Denis Korkhov
//  *
//  */
#endregion
using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Cortoxa.Container;
using Cortoxa.Container.Registrator;

namespace Cortoxa.Web.MVC.Factories
{
    public class ControllerFactory : DefaultControllerFactory
    {
        private readonly IToolContainer container;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="resolver"></param>
        public ControllerFactory(IToolContainer container)
        {
            this.container = container;
        }

        /// <summary>
        /// Release the controller at the end of it's life cycle
        /// </summary>
        /// <param name="controller">The Interface to an MVC controller</param>
        public override void ReleaseController(IController controller)
        { 
            container.Release(controller);
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            if (controllerType == null)
            {
                throw new HttpException(404, string.Format("The controller for path '{0}' could not be found.", requestContext.HttpContext.Request.Path));
            }

            return (Controller)container.Resolver.Resolve(controllerType);
        }
    }
}
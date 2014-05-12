using System;
using System.Collections.Generic;
using System.Reflection;
using Cortoxa.Container.Life;

namespace Cortoxa.Web.MVC.Controllers
{
    public class ControllersContext
    {
        private readonly IList<Assembly> assemblies = new List<Assembly>();

        public LifeTime LifeTime { get; set; }
        public Type ControllerType { get; set; }

        public IList<Assembly> Assemblies
        {
            get { return assemblies; }
        }
    }
}
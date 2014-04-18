using System;
using System.Reflection;
using Cortoxa.Container.Life;

namespace Cortoxa.Web.MVC.Controllers
{
    public class ControllersContext
    {
        public LifeTime LifeTime { get; set; }
        public Type ControllerType { get; set; }
        public Assembly[] Assemblies { get; set; }
    }
}
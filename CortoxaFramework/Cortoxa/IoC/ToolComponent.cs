using System;
using System.Collections.Generic;
using Cortoxa.Components;
using Cortoxa.IoC.Base;
using Cortoxa.IoC.Service;

namespace Cortoxa.IoC
{
    public class ToolComponent<T> : IToolComponent<T> where T : IServiceComponent
    {
        private readonly IList<IRegistrationStratagy> stratagies = new List<IRegistrationStratagy>();

        private readonly IToolDependency dependency;
        
        private string name;

        public ToolComponent()
        {
//            dependency = new ToolDependency();
        }

        public static IToolComponent<T> Create(Action<IToolComponent<T>> doAction)
        {
            var component = new ToolComponent<T>();
            doAction(component);
            return component;
        }

        public IToolComponent<T> Named(string name)
        {
            this.name = name;
            return this;
        }

        public IToolDependency Depend
        {
            get { return dependency; }
        }

        public void Register(IToolRegistrator container)
        {
            foreach (var registrationStratagy in stratagies)
            {
                registrationStratagy.Register(container);
            }
        }

        public void Add(Action<IServiceBuilderFor> serviceAction)
        {
            var service = new ServiceBuilder();
            stratagies.Add(service);
            serviceAction(service);
        }

//        public void DependOn<TS>(string dependencyName)
//        {
//            this.DependOn(typeof(TS), dependencyName);
//        }
//
//        public void DependOn(Type serviceType, string dependencyName)
//        {
//            dependencies.Add(dependencyName, serviceType);
//        }
    }
}
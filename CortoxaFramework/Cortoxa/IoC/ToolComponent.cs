using System;
using System.Collections.Generic;
using Cortoxa.Components;
using Cortoxa.IoC.Base;

namespace Cortoxa.IoC
{
    public class ToolComponent<T> : IToolComponent<T>
    {
        private readonly IList<IRegistrationStratagy> stratagies = new List<IRegistrationStratagy>();
        private string name;

        public ToolComponent()
        {
        
        }

        public void OnRegister(Action<IToolRegistrator> action)
        {
//            action(registrator);
        }

        public void AddRegistration(IRegistrationStratagy serviceRegistration)
        {
            stratagies.Add(serviceRegistration);
        }

        public IToolComponent<T> Named(string name)
        {
            this.name = name;
            return this;
        }

        public void Register(IToolRegistrator container)
        {
            foreach (var stratagy in stratagies)
            {
                stratagy.Register(container);
            }
        }
    }
}
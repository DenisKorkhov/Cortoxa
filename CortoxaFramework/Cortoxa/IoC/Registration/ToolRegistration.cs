using System;
using System.CodeDom;
using System.Collections.Generic;
using Cortoxa.IoC.Common;
using Cortoxa.IoC.Component;
using Cortoxa.IoC.Service;

namespace Cortoxa.IoC.Registration
{
    public class ToolRegistration : IRegistration
    {
        private readonly Action<IRegistrationContext> serviceRegistration;
        private readonly IList<Action> registrations = new List<Action>();

        public ToolRegistration(Action<IRegistrationContext> serviceRegistration)
        {
            this.serviceRegistration = serviceRegistration;
        }

        public IServiceBuilder For(params Type[] types)
        {
            var result = new ServiceBuilder(types);
            registrations.Add(() => result.Register(serviceRegistration));
            return result;
        }

        public IComponentBuilder Component<T>(Action<ISetupConfigurator<T>> action)
        {
            var result = new ComponentBuilder();
//            registrations.Add(() => result.Register(serviceRegistration));
            return result;
        }

        public TypeRegistration Types()
        {
            throw new NotImplementedException();
        }
      
        public void Build()
        {
            foreach (var registration in registrations)
            {
                registration();
            }
        }
    }
}

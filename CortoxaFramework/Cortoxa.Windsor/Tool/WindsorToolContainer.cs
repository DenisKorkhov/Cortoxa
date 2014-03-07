using System;
using System.Linq;
using Castle.Windsor;
using Cortoxa.IoC;
using Cortoxa.IoC.Common;
using Cortoxa.IoC.Registration;
using Cortoxa.Windsor.Registrators;

namespace Cortoxa.Windsor.Tool
{
    public class WindsorToolContainer : IToolContainer
    {
        private readonly IWindsorContainer container;

        public WindsorToolContainer(IWindsorContainer container)
        {
            this.container = container;
        }

        public IToolContainer Register(Action<IRegistration> registrationAction)
        {
            var registrator = new ToolRegistration(WindsorServiceRegistrator.RegistrationAction(container));
            registrationAction(registrator);
            registrator.Build();
            return this;
        }

        public T Resolve<T>(object arguments = null)
        {
            return arguments != null ? container.Resolve<T>(arguments) : container.Resolve<T>();
        }

        public object Resolve(Type type, object arguments = null)
        {
            return arguments != null ? container.Resolve(type, arguments) : container.Resolve(type);
        }

        public T Resolve<T>(Type type, object arguments = null)
        {
            var result = arguments != null ? (T)container.Resolve(type, arguments) : container.Resolve(type);
            return (T)result;
        }

        public T Resolve<T>(string key, object arguments = null)
        {
            return arguments != null ? container.Resolve<T>(key, arguments) : container.Resolve<T>(key);
        }

        public T[] ResolveAll<T>(object arguments = null)
        {
            return arguments != null ? container.ResolveAll<T>(arguments) : container.ResolveAll<T>();
        }

        public object[] ResolveAll(Type type, object arguments = null)
        {
            var result = arguments != null ? container.ResolveAll(type, arguments) : container.ResolveAll(type);
            return result.Cast<object>().ToArray();
        }

        public T[] ResolveAll<T>(Type type, object arguments = null)
        {
            var result = arguments != null ? container.ResolveAll(type, arguments) : container.ResolveAll(type);
            return result.Cast<T>().ToArray();
        }

        public void Release(Type type)
        {
            var instance = Resolve(type);
            if (instance != null)
            {
                container.Release(instance);
            }
        }

        public void Release(object instance)
        {
            container.Release(instance);
        }
    }
}
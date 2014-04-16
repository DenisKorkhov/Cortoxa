using System;
using System.Linq;
using Castle.Windsor;
using Cortoxa.Container.Registrator;

namespace Cortoxa.Windsor.Tool
{
    public class WindsorResolver : IResolver
    {
        private readonly IWindsorContainer container;

        public WindsorResolver(IWindsorContainer container)
        {
            this.container = container;
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
            object result = arguments != null ? (T)container.Resolve(type, arguments) : container.Resolve(type);
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
            Array result = arguments != null ? container.ResolveAll(type, arguments) : container.ResolveAll(type);
            return result.Cast<object>().ToArray();
        }

        public T[] ResolveAll<T>(Type type, object arguments = null)
        {
            Array result = arguments != null ? container.ResolveAll(type, arguments) : container.ResolveAll(type);
            return result.Cast<T>().ToArray();
        }

        public void Release(Type type)
        {
            var instance = Resolve(type);
            if (instance != null)
            {
                Release(instance);
            }
        }

        public void Release(object instance)
        {
            container.Release(instance);
        }
    }
}
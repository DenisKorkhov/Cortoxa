using System;
using System.Linq.Expressions;
using System.Reflection;
using Cortoxa.Common.Configuration;
using Cortoxa.Components;
using Cortoxa.Container.Registrator;
using Cortoxa.Reflection;


namespace Cortoxa.Container.Components
{
    public class ComponentRegistrator : IConfigurator<ComponentContext>, IComponentRegistrator
    {
        private readonly IRegistration registrator;

        public ComponentRegistrator(IRegistration registrator)
        {
            this.registrator = registrator;
        }

        public ComponentContext Context { get; private set; }

        public void Configure()
        {
        }

        public IComponentConfigurator<T> Configure<T>(Expression<Func<T, object>> propertyExpression, Func<IRegistration, object> registrationAction) where T : IComponent, new()
        {
            var property = propertyExpression.MemberInfo().Member as PropertyInfo;
            var component = new T();
            if (property != null)
            {
                var configurationValue = registrationAction(registrator);
                #if NET35 || NET40
                property.SetValue(component, configurationValue, null);
                #else
                property.SetValue(component, configurationValue);
#endif
            }
            var configurator = new ComponentConfigurator<T>(component);
            return configurator;
        }

        public IRegistration Registrator
        {
            get { return registrator; }
        }
    }
}
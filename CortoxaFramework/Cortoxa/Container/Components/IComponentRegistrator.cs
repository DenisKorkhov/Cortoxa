using System;
using System.Linq.Expressions;
using Cortoxa.Common.Configuration;
using Cortoxa.Components;
using Cortoxa.Container.Registrator;

namespace Cortoxa.Container.Components
{
    public interface IComponentRegistrator
    {
        IComponentConfigurator<T> Configure<T>(Expression<Func<T, object>> propertyExpression, Func<IRegistration, object> registrationAction) where T : IComponent, new();

        IRegistration Registrator { get;  }
    }
}
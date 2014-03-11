using System;
using System.Linq.Expressions;
using Cortoxa.Components;

namespace Cortoxa.Container.Components
{
    public interface IComponentConfigurator<T> where T : IComponent
    {
        void Init();

        IComponentConfigurator<T> Configure(Expression<Func<T, T>> property);

        IComponentConfigurator<T> Update(Action<T> updateAction);
    }
}
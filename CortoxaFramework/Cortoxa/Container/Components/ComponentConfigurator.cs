using System;
using System.Linq.Expressions;
using Cortoxa.Common.Configuration;
using Cortoxa.Components;

namespace Cortoxa.Container.Components
{
    public class ComponentConfigurator<T> : IComponentConfigurator<T>, IConfigurator<T> where T : IComponent
    {
        private readonly T component;

        public ComponentConfigurator(T component)
        {
            this.component = component;
        }

        public virtual void Init()
        {
        }

        public IComponentConfigurator<T> Configure(Expression<Func<T, T>> property)
        {
            return this;
        }

        public IComponentConfigurator<T> Update(Action<T> updateAction)
        {
            updateAction(component);
            return this;
        }

        public T Context
        {
            get { return component; }
        }

        public void Configure()
        {
        }
    }
}
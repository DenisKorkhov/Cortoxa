using System;
using System.Collections.Generic;
using Cortoxa.Container.Life;

namespace Cortoxa.Container.Services
{
    public interface IServiceContext
    {
        Type[] For { get; set; }
        Type To { get; set; }
        Func<FactoryContext, object> ToFactory { get; set; }
        string Name { get; set; }
        LifeTime Lifetime { get; set; }
        IDictionary<Type, string> ComponentDependencies { get; }
        IList<MethodInteception> Interceptors { get; }
        IDictionary<string, object> ValueDependencies { get; }
    }
}
using System;
using System.Collections.Generic;
using Cortoxa.Container.Life;

namespace Cortoxa.Container.Services
{
    public class ServiceContext : IServiceContext
    {
        private readonly IDictionary<Type, string> componentDependencies = new Dictionary<Type, string>();
        private readonly IDictionary<string, object> valueDependencies = new Dictionary<string, object>();

        private readonly IList<MethodInteception> interceptors = new List<MethodInteception>();

        public Type[] For { get; set; }

        public Type To { get; set; }

        public Func<FactoryContext, object> ToFactory { get; set; }

        public string Name { get; set; }

        public LifeTime Lifetime { get; set; }

        public IDictionary<Type, string> ComponentDependencies
        {
            get { return componentDependencies; }
        }

        public IDictionary<string, object> ValueDependencies
        {
            get { return valueDependencies; }
        }

        public IList<MethodInteception> Interceptors
        {
            get { return interceptors; }
        }
    }
}
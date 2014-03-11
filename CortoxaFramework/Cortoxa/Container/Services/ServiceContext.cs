using System;
using System.Collections.Generic;
using Cortoxa.Container.Common;

namespace Cortoxa.Container.Services
{
    public class ServiceContext 
    {
        private readonly IDictionary<Type, string> dependencies = new Dictionary<Type, string>();

        private readonly IList<MethodInteception> interceptors = new List<MethodInteception>();

        public Type[] For { get; set; }

        public Type To { get; set; }

        public Func<FactoryContext, object> ToFactory { get; set; }

        public string Name { get; set; }

        public LifeTime Lifetime { get; set; }

        public IDictionary<Type, string> Dependencies
        {
            get { return dependencies; }
        }

        public IList<MethodInteception> Interceptors
        {
            get { return interceptors; }
        }
    }
}
using System;
using System.Collections.Generic;
using Cortoxa.IoC.Base;

namespace Cortoxa.IoC
{
    public class ToolDependency : IToolDependency
    {
//        private readonly IDictionary<string, Type> dependencies = new Dictionary<string, Type>();
//
//        public IDictionary<string, Type> Dependencies
//        {
//            get { return dependencies; }
//        }


//        public void Apply(IToolDependency dependency)
//        {
//            
//        }

//        public string Name { get; set; }
        public void On(IDictionary<string, Type> dependencies)
        {
            throw new NotImplementedException();
        }
    }
}
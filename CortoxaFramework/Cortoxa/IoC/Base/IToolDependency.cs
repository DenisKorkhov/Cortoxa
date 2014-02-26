using System;
using System.Collections.Generic;

namespace Cortoxa.IoC.Base
{
    public interface IToolDependency
    {
//        IDictionary<string, Type> Dependencies { get; }

//        void Apply(IToolDependency dependency);

        void On(IDictionary<string, Type> dependencies);

//
//        string Name { get; set; }
    }
}
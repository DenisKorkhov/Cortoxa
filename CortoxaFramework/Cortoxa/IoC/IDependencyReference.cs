using System;
using System.Collections.Generic;

namespace Cortoxa.IoC
{
    public interface IDependencyReference
    {
        string Name { get; set; }

        IDictionary<string, Type> Referencies { get; }
    }
}
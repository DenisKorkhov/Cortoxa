
using System;
using System.Reflection;
using Cortoxa.Container.Life;

namespace Cortoxa.Container.Types
{
    public class TypeContext
    {
        public Assembly[] Assemblies { get; set; }

        public Func<Type, bool> Where { get; set; }

        public string Name { get; set; }

        public LifeTime LifeTime { get; set; }

        public TypeServiceSourceEnum ServiceSource { get; set; }
    }

    public enum TypeServiceSourceEnum
    {
        Class,
        Interface
    }
}
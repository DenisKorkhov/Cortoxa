using System;

namespace Cortoxa.Common
{
    public static class TypeExtentions
    {
        public static bool BasedOn(this Type type, Type baseType)
        {
            return type.IsInstanceOfType(baseType) || type.IsSubclassOf(baseType);
        }
    }
}
using System;

namespace Cortoxa.Common
{
    public static class TypeExtentions
    {
        public static bool BasedOn(this Type type, Type baseType)
        {
            return type.IsInstanceOfType(baseType) || type.IsSubclassOf(baseType) || type.IsAssignableFrom(baseType);
        }

        public static Type InGeneric(this Type typeParameter, Type genericDefinityinType)
        {
            return genericDefinityinType.MakeGenericType(typeParameter);
        }
    }
}
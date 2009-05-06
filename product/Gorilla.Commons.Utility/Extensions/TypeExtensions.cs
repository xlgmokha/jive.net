using System;
using System.Linq;
using System.Reflection;

namespace Gorilla.Commons.Utility.Extensions
{
    public static class TypeExtensions
    {
        public static Type last_interface(this Type type)
        {
            return type.GetInterfaces()[type.GetInterfaces().Length - 1];
        }

        public static Type first_interface(this Type type)
        {
            return type.GetInterfaces()[0];
        }

        public static bool is_a_generic_type(this Type type)
        {
            //return type.IsGenericType;
            return type.IsGenericTypeDefinition;
        }

        public static object default_value(this Type type)
        {
            return (type.IsValueType ? Activator.CreateInstance(type) : null);
        }

        public static Attribute get_attribute<Attribute>(this ICustomAttributeProvider provider)
            where Attribute : System.Attribute
        {
            return
                provider
                    .GetCustomAttributes(typeof (Attribute), false)
                    .Select(x => x.downcast_to<Attribute>())
                    .First();
        }
    }
}
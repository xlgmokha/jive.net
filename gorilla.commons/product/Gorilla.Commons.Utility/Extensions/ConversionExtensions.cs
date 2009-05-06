using System;
using System.Collections;

namespace Gorilla.Commons.Utility.Extensions
{
    public static class ConversionExtensions
    {
        public static T downcast_to<T>(this object object_to_cast)
        {
            return (T) object_to_cast;
        }

        public static T converted_to<T>(this object item_to_convert)
        {
            if (item_to_convert.is_an_implementation_of<IConvertible>())
            {
                return (T) Convert.ChangeType(item_to_convert, typeof (T));
            }
            return item_to_convert.downcast_to<T>();
        }

        public static bool is_an_implementation_of<T>(this object item)
        {
            return item is T;
        }

        public static void call_on<T>(this object target, Action<T> action) where T : class
        {
            if (target as T != null) action(target as T);
        }

        public static void call_on_each<T>(this IEnumerable items, Action<T> action) where T : class
        {
            foreach (var item in items) item.call_on(action);
        }
    }
}
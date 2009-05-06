using System;
using System.Collections.Generic;
using System.Linq;
using Gorilla.Commons.Utility.Core;

namespace Gorilla.Commons.Utility.Extensions
{
    public static class RegistryExtensions
    {
        public static K find_an_implementation_of<T, K>(this IRegistry<T> registry) where K : T
        {
            try
            {
                return registry
                    .all()
                    .Single(p => p.is_an_implementation_of<K>())
                    .downcast_to<K>();
            }
            catch (Exception exception)
            {
                throw new Exception("Could Not Find an implementation of".formatted_using(typeof (K)), exception);
            }
        }

        public static IEnumerable<T> sort_all_using<T>(this IRegistry<T> registry, IComparer<T> comparer)
        {
            return registry.all().sorted_using(comparer);
        }
    }
}
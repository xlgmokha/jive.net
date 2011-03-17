using System;
using System.Collections.Generic;
using System.Linq;

namespace gorilla.utility
{
    public static class RegistryExtensions
    {
        public static K find_an_implementation_of<T, K>(this Registry<T> registry) where K : T
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
                throw new Exception("Could Not Find an implementation of".format(typeof (K)), exception);
            }
        }

        public static IEnumerable<T> sort_all_using<T>(this Registry<T> registry, IComparer<T> comparer)
        {
            return registry.all().sorted_using(comparer);
        }
    }
}
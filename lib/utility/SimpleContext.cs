using System.Collections;

namespace gorilla.utility
{
    public class SimpleContext : Context
    {
        Hashtable items;

        public SimpleContext(Hashtable items)
        {
            this.items = items;
        }

        public bool contains<T>(Key<T> key)
        {
            return key.is_found_in(items);
        }

        public void add<T>(Key<T> key, T value)
        {
            key.add_value_to(items, value);
        }

        public T value_for<T>(Key<T> key)
        {
            return key.parse_from(items);
        }

        public void remove<T>(Key<T> key)
        {
            key.remove_from(items);
        }
    }
}
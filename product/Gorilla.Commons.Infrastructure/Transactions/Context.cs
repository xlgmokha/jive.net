using System.Collections;

namespace Gorilla.Commons.Infrastructure.Transactions
{
    public class Context : IContext
    {
        readonly IDictionary items;

        public Context(IDictionary items)
        {
            this.items = items;
        }

        public bool contains<T>(IKey<T> key)
        {
            return key.is_found_in(items);
        }

        public void add<T>(IKey<T> key, T value)
        {
            key.add_value_to(items, value);
        }

        public T value_for<T>(IKey<T> key)
        {
            return key.parse_from(items);
        }

        public void remove<T>(IKey<T> key)
        {
            key.remove_from(items);
        }
    }
}
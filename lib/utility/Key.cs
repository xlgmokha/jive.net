using System.Collections;

namespace gorilla.utility
{
    public interface Key<T>
    {
        bool is_found_in(IDictionary items);
        T parse_from(IDictionary items);
        void remove_from(IDictionary items);
        void add_value_to(IDictionary items, T value);
    }
}
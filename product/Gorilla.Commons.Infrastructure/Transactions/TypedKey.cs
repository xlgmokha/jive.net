using System.Collections;

namespace Gorilla.Commons.Infrastructure.Transactions
{
    public class TypedKey<T> : IKey<T>
    {
        public bool is_found_in(IDictionary items)
        {
            return items.Contains(create_key());
        }

        public T parse_from(IDictionary items)
        {
            return (T) items[create_key()];
        }

        public void remove_from(IDictionary items)
        {
            if (is_found_in(items)) items.Remove(create_key());
        }

        public void add_value_to(IDictionary items, T value)
        {
            items[create_key()] = value;
        }

        public bool Equals(TypedKey<T> obj)
        {
            return !ReferenceEquals(null, obj);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (TypedKey<T>)) return false;
            return Equals((TypedKey<T>) obj);
        }

        public override int GetHashCode()
        {
            return GetType().GetHashCode();
        }

        string create_key()
        {
            return GetType().FullName;
        }
    }
}
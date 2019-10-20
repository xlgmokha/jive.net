using System.Linq;

namespace gorilla.utility
{
    public class ValueType<T>
    {
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (!(obj is ValueType<T>)) return false;
            return Equals((ValueType<T>) obj);
        }

        public bool Equals(ValueType<T> other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return PropertiesMatch(other);
        }

        bool PropertiesMatch(ValueType<T> other)
        {
            return !GetType().GetProperties().Any(x =>
            {
                var thisValue = x.GetValue(this, null);
                var otherValue = x.GetValue(other, null);
                return !thisValue.Equals(otherValue);
            });
        }

        public override int GetHashCode()
        {
            return GetType().GetProperties().Aggregate(0, (prev, prop) => (prev*397) ^ prop.GetHashCode());
        }
    }
}
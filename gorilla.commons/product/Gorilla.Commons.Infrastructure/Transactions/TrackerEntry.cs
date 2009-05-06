using System.Reflection;
using Gorilla.Commons.Infrastructure.Logging;

namespace Gorilla.Commons.Infrastructure.Transactions
{
    public interface ITrackerEntry<T>
    {
        T current { get; }
        bool has_changes();
    }

    public class TrackerEntry<T> : ITrackerEntry<T>
    {
        readonly T original;

        public TrackerEntry(T original, T current)
        {
            this.original = original;
            this.current = current;
        }

        public T current { get; set; }

        public bool has_changes()
        {
            this.log().debug("checking for changes");
            var type = original.GetType();
            foreach (var field in type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance))
            {
                var original_value = field.GetValue(original);
                var current_value = field.GetValue(current);
                if (original_value == null && current_value != null)
                {
                    this.log().debug("{0} has changes: {1}", field, original);
                    return true;
                }
                if (original_value != null && !original_value.Equals(current_value))
                {
                    this.log().debug("{0} has changes: {1}", field, original);
                    return true;
                }
            }
            this.log().debug("has no changes: {0}", original);
            return false;
        }
    }
}
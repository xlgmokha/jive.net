using System.Collections;

namespace Gorilla.Commons.Infrastructure.Transactions
{
    public class PerThreadScopedStorage : IScopedStorage
    {
        readonly IThread current_thread;

        public PerThreadScopedStorage(IThread current_thread)
        {
            this.current_thread = current_thread;
        }

        public IDictionary provide_storage()
        {
            return current_thread.provide_slot_for<Hashtable>();
        }
    }
}
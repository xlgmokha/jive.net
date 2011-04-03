using System.Collections;
using gorilla.utility;

namespace gorilla.infrastructure.threading
{
    public class PerThreadScopedStorage : ScopedStorage
    {
        readonly ApplicationThread current_thread;

        public PerThreadScopedStorage(ApplicationThread current_thread)
        {
            this.current_thread = current_thread;
        }

        public IDictionary provide_storage()
        {
            return current_thread.provide_slot_for<Hashtable>();
        }
    }
}
using System;
using System.Collections.Generic;

namespace Gorilla.Commons.Infrastructure.Transactions
{
    public class Thread : IThread
    {
        readonly object mutex = new object();
        readonly IDictionary<int, LocalDataStoreSlot> slots;

        public Thread()
        {
            slots = new Dictionary<int, LocalDataStoreSlot>();
        }

        public T provide_slot_for<T>() where T : new()
        {
            var id = System.Threading.Thread.CurrentThread.ManagedThreadId;
            within_lock(() =>
                            {
                                if (!slots.ContainsKey(id))
                                {
                                    var slot = System.Threading.Thread.GetNamedDataSlot(GetType().FullName);
                                    slots.Add(id, slot);
                                    System.Threading.Thread.SetData(slot, new T());
                                }
                            });
            return (T) System.Threading.Thread.GetData(slots[id]);
        }

        void within_lock(Action action)
        {
            lock (mutex) action();
        }
    }
}
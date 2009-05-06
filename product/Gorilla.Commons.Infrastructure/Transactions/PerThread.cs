using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

namespace Gorilla.Commons.Infrastructure.Transactions
{
    public class PerThread : IContext
    {
        readonly IDictionary<int, LocalDataStoreSlot> slots;
        readonly object mutex = new object();

        public PerThread()
        {
            slots = new Dictionary<int, LocalDataStoreSlot>();
        }

        public bool contains<T>(IKey<T> key)
        {
            return key.is_found_in(get_items());
        }

        public void add<T>(IKey<T> key, T value)
        {
            key.add_value_to(get_items(), value);
        }

        public T value_for<T>(IKey<T> key)
        {
            return key.parse_from(get_items());
        }

        public void remove<T>(IKey<T> key)
        {
            key.remove_from(get_items());
        }

        IDictionary get_items()
        {
            var id = Thread.CurrentThread.ManagedThreadId;
            within_lock(() =>
                            {
                                if (!slots.ContainsKey(id))
                                {
                                    var slot = Thread.GetNamedDataSlot(GetType().FullName);
                                    slots.Add(id, slot);
                                    Thread.SetData(slot, new Hashtable());
                                }
                            });
            return (IDictionary) Thread.GetData(slots[id]);
        }

        void within_lock(Action action)
        {
            lock (mutex) action();
        }
    }
}
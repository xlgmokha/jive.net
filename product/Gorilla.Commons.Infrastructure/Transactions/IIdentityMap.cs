using System.Collections.Generic;

namespace Gorilla.Commons.Infrastructure.Transactions
{
    public interface IIdentityMap<TKey, TValue>
    {
        IEnumerable<TValue> all();
        void add(TKey key, TValue value);
        void update_the_item_for(TKey key, TValue new_value);
        bool contains_an_item_for(TKey key);
        TValue item_that_belongs_to(TKey key);
        void evict(TKey key);
    }

    public class IdentityMap<TKey, TValue> : IIdentityMap<TKey, TValue>
    {
        readonly IDictionary<TKey, TValue> items_in_map;

        public IdentityMap() : this(new Dictionary<TKey, TValue>())
        {
        }

        public IdentityMap(IDictionary<TKey, TValue> items_in_map)
        {
            this.items_in_map = items_in_map;
        }

        public IEnumerable<TValue> all()
        {
            return items_in_map.Values;
        }

        public void add(TKey key, TValue value)
        {
            items_in_map.Add(key, value);
        }

        public void update_the_item_for(TKey key, TValue new_value)
        {
            if (contains_an_item_for(key)) items_in_map[key] = new_value;
            else add(key, new_value);
        }

        public bool contains_an_item_for(TKey key)
        {
            return items_in_map.ContainsKey(key);
        }

        public TValue item_that_belongs_to(TKey key)
        {
            return contains_an_item_for(key) ? items_in_map[key] : default(TValue);
        }

        public void evict(TKey key)
        {
            if (contains_an_item_for(key)) items_in_map.Remove(key);
        }
    }
}
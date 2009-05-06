using System;
using System.Collections.Generic;
using System.Linq;
using Gorilla.Commons.Infrastructure.Logging;
using Gorilla.Commons.Utility.Core;
using Gorilla.Commons.Utility.Extensions;

namespace Gorilla.Commons.Infrastructure.Transactions
{
    public interface ISession : IDisposable
    {
        T find<T>(Guid guid) where T : IIdentifiable<Guid>;
        IEnumerable<T> all<T>() where T : IIdentifiable<Guid>;
        void save<T>(T entity) where T : IIdentifiable<Guid>;
        void delete<T>(T entity) where T : IIdentifiable<Guid>;
        void flush();
        bool is_dirty();
    }

    public class Session : ISession
    {
        ITransaction transaction;
        readonly IDatabase database;
        readonly IDictionary<Type, object> identity_maps;
        long id;

        public Session(ITransaction transaction, IDatabase database)
        {
            this.database = database;
            this.transaction = transaction;
            identity_maps = new Dictionary<Type, object>();
            id = DateTime.Now.Ticks;
        }

        public T find<T>(Guid id) where T : IIdentifiable<Guid>
        {
            if (get_identity_map_for<T>().contains_an_item_for(id))
            {
                return get_identity_map_for<T>().item_that_belongs_to(id);
            }

            var entity = database.fetch_all<T>().Single(x => x.id.Equals(id));
            get_identity_map_for<T>().add(id, entity);
            return entity;
        }

        public IEnumerable<T> all<T>() where T : IIdentifiable<Guid>
        {
            database
                .fetch_all<T>()
                .where(x => !get_identity_map_for<T>().contains_an_item_for(x.id))
                .each(x => get_identity_map_for<T>().add(x.id, x));
            return get_identity_map_for<T>().all();
        }

        public void save<T>(T entity) where T : IIdentifiable<Guid>
        {
            this.log().debug("saving {0}: {1}", id, entity);
            get_identity_map_for<T>().add(entity.id, entity);
        }

        public void delete<T>(T entity) where T : IIdentifiable<Guid>
        {
            get_identity_map_for<T>().evict(entity.id);
        }

        public void flush()
        {
            this.log().debug("flushing session {0}", id);
            transaction.commit_changes();
            transaction = null;
        }

        public bool is_dirty()
        {
            this.log().debug("is dirty? {0}", id);
            return null != transaction && transaction.is_dirty();
        }

        public void Dispose()
        {
            if (null != transaction) transaction.rollback_changes();
        }

        IIdentityMap<Guid, T> get_identity_map_for<T>() where T : IIdentifiable<Guid>
        {
            return identity_maps.ContainsKey(typeof (T))
                       ? identity_maps[typeof (T)].downcast_to<IIdentityMap<Guid, T>>()
                       : create_map_for<T>();
        }

        IIdentityMap<Guid, T> create_map_for<T>() where T : IIdentifiable<Guid>
        {
            var identity_map = transaction.create_for<T>();
            identity_maps.Add(typeof (T), identity_map);
            return identity_map;
        }

        public override string ToString()
        {
            return "session: {0}".formatted_using(id);
        }
    }
}
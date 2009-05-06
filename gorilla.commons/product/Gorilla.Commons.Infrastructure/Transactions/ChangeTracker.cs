using System;
using System.Collections.Generic;
using System.Linq;
using Gorilla.Commons.Infrastructure.Logging;
using Gorilla.Commons.Utility.Core;
using Gorilla.Commons.Utility.Extensions;

namespace Gorilla.Commons.Infrastructure.Transactions
{
    public class ChangeTracker<T> : IChangeTracker<T> where T : IIdentifiable<Guid>
    {
        readonly ITrackerEntryMapper<T> mapper;
        readonly IStatementRegistry registry;
        readonly IList<ITrackerEntry<T>> items;
        readonly IList<T> to_be_deleted;

        public ChangeTracker(ITrackerEntryMapper<T> mapper, IStatementRegistry registry)
        {
            this.mapper = mapper;
            this.registry = registry;
            items = new List<ITrackerEntry<T>>();
            to_be_deleted = new List<T>();
        }

        public void register(T entity)
        {
            this.log().debug("registered: {0}", entity);
            items.Add(mapper.map_from(entity));
        }

        public void delete(T entity)
        {
            to_be_deleted.Add(entity);
        }

        public void commit_to(IDatabase database)
        {
            items.each(x => this.log().debug("committing: {0}", x.current));
            items.each(x => commit(x, database));
            to_be_deleted.each(x => database.apply(registry.prepare_command_for(x)));
        }

        public bool is_dirty()
        {
            this.log().debug("is change tracker dirty? {0}",items.Count(x => x.has_changes()) );
            return items.Count(x => x.has_changes()) > 0 || to_be_deleted.Count > 0;
        }

        public void Dispose()
        {
            items.Clear();
        }

        void commit(ITrackerEntry<T> entry, IDatabase database)
        {
            if (entry.has_changes()) database.apply(registry.prepare_command_for(entry.current));
        }
    }
}
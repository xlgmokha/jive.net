using System;
using Gorilla.Commons.Infrastructure.Container;
using Gorilla.Commons.Utility.Core;

namespace Gorilla.Commons.Infrastructure.Transactions
{
    public class ChangeTrackerFactory : IChangeTrackerFactory
    {
        readonly IStatementRegistry statement_registry;
        readonly IDependencyRegistry registry;

        public ChangeTrackerFactory(IStatementRegistry statement_registry, IDependencyRegistry registry)
        {
            this.statement_registry = statement_registry;
            this.registry = registry;
        }

        public IChangeTracker<T> create_for<T>() where T : IIdentifiable<Guid>
        {
            return new ChangeTracker<T>(registry.get_a<ITrackerEntryMapper<T>>(), statement_registry);
        }
    }
}
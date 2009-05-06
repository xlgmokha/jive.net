using System;
using Gorilla.Commons.Utility.Core;

namespace Gorilla.Commons.Infrastructure.Transactions
{
    public interface IChangeTrackerFactory
    {
        IChangeTracker<T> create_for<T>() where T : IIdentifiable<Guid>;
    }
}
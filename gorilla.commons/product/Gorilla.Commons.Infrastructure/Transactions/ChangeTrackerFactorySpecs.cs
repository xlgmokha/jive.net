using System;
using developwithpassion.bdd.contexts;
using Gorilla.Commons.Testing;
using Gorilla.Commons.Utility.Core;

namespace Gorilla.Commons.Infrastructure.Transactions
{
    public class ChangeTrackerFactorySpecs
    {
    }

    public class when_creating_a_change_tracker_for_an_item : concerns_for<IChangeTrackerFactory, ChangeTrackerFactory>
    {
        it should_return_a_new_tracker = () => result.should_not_be_null();

        because b = () => { result = sut.create_for<IIdentifiable<Guid>>(); };

        static IChangeTracker<IIdentifiable<Guid>> result;
    }
}
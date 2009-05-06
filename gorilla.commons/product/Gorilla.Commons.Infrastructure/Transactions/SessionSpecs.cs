using System;
using System.Collections.Generic;
using developwithpassion.bdd.contexts;
using Gorilla.Commons.Testing;
using Gorilla.Commons.Utility.Core;

namespace Gorilla.Commons.Infrastructure.Transactions
{
    public class SessionSpecs
    {
    }

    public class behaves_like_session : concerns_for<ISession, Session>
    {
        context c = () =>
                        {
                            transaction = the_dependency<ITransaction>();
                            database = the_dependency<IDatabase>();
                        };

        static protected ITransaction transaction;
        static protected IDatabase database;
    }

    public class when_saving_a_transient_item_to_a_session : behaves_like_session
    {
        it should_add_the_entity_to_the_identity_map = () => map.was_told_to(x => x.add(guid, entity));

        //it should_add_the_item_to_the_current_transaction = () => transaction.was_told_to(x => x.add_transient(entity));

        context c = () =>
                        {
                            guid = Guid.NewGuid();
                            entity = an<ITestEntity>();
                            map = an<IIdentityMap<Guid, ITestEntity>>();

                            when_the(entity).is_told_to(x => x.id).it_will_return(guid);
                            when_the(transaction).is_told_to(x => x.create_for<ITestEntity>()).it_will_return(map);
                        };

        because b = () => sut.save(entity);

        static ITestEntity entity;
        static IIdentityMap<Guid, ITestEntity> map;
        static Guid guid;
    }

    public class when_commiting_the_changes_made_in_a_session : behaves_like_session
    {
        it should_commit_all_the_changes_from_the_running_transaction =
            () => transaction.was_told_to(x => x.commit_changes());

        it should_not_rollback_any_changes_from_the_running_transaction =
            () => transaction.was_not_told_to(x => x.rollback_changes());

        because b = () =>
                        {
                            sut.flush();
                            sut.Dispose();
                        };
    }

    public class when_closing_a_session_before_flushing_the_changes : behaves_like_session
    {
        it should_rollback_any_changes_made_in_the_current_transaction =
            () => transaction.was_told_to(x => x.rollback_changes());

        because b = () => sut.Dispose();
    }

    public class when_loading_all_instances_of_a_certain_type_and_some_have_already_been_loaded : behaves_like_session
    {
        it should_return_the_items_from_the_cache = () => results.should_contain(cached_item);

        it should_exclude_duplicates_from_the_database = () => results.should_not_contain(database_item);

        it should_add_items_from_the_database_to_the_identity_map =
            () => identity_map.was_told_to(x => x.add(id_of_the_uncached_item, uncached_item));

        context c = () =>
                        {
                            id = Guid.NewGuid();
                            id_of_the_uncached_item = Guid.NewGuid();
                            identity_map = an<IIdentityMap<Guid, ITestEntity>>();
                            cached_item = an<ITestEntity>();
                            database_item = an<ITestEntity>();
                            uncached_item = an<ITestEntity>();

                            when_the(cached_item).is_told_to(x => x.id).it_will_return(id);
                            when_the(database_item).is_told_to(x => x.id).it_will_return(id);
                            when_the(uncached_item).is_told_to(x => x.id).it_will_return(id_of_the_uncached_item);
                            when_the(transaction).is_told_to(x => x.create_for<ITestEntity>()).it_will_return(
                                identity_map);
                            when_the(identity_map).is_told_to(x => x.contains_an_item_for(id)).it_will_return(true);
                            when_the(identity_map).is_told_to(x => x.all()).it_will_return(cached_item);
                            when_the(database).is_told_to(x => x.fetch_all<ITestEntity>())
                                .it_will_return(database_item, uncached_item);
                        };

        because b = () =>
                        {
                            sut.find<ITestEntity>(id);
                            results = sut.all<ITestEntity>();
                        };

        static IEnumerable<ITestEntity> results;
        static Guid id;
        static Guid id_of_the_uncached_item;
        static ITestEntity cached_item;
        static ITestEntity database_item;
        static IIdentityMap<Guid, ITestEntity> identity_map;
        static ITestEntity uncached_item;
    }

    public class when_looking_up_a_specific_entity_by_its_id_and_it_has_not_been_loaded_into_the_cache :
        behaves_like_session
    {
        it should_return_that_item = () => { result.should_be_equal_to(correct_item); };

        it should_add_that_item_to_the_identity_map = () => map.was_told_to(x => x.add(id, correct_item));

        context c = () =>
                        {
                            id = Guid.NewGuid();
                            wrong_item = an<ITestEntity>();
                            correct_item = an<ITestEntity>();
                            map = an<IIdentityMap<Guid, ITestEntity>>();
                            when_the(wrong_item).is_told_to(x => x.id).it_will_return(Guid.NewGuid());
                            when_the(correct_item).is_told_to(x => x.id).it_will_return(id);
                            when_the(database)
                                .is_told_to(x => x.fetch_all<ITestEntity>())
                                .it_will_return(wrong_item, correct_item);
                            when_the(transaction).is_told_to(x => x.create_for<ITestEntity>())
                                .it_will_return(map);
                        };

        because b = () => { result = sut.find<ITestEntity>(id); };

        static Guid id;
        static IIdentifiable<Guid> result;
        static ITestEntity correct_item;
        static ITestEntity wrong_item;
        static IIdentityMap<Guid, ITestEntity> map;
    }

    public class when_deleting_an_item_from_the_database : behaves_like_session
    {
        it should_remove_that_item_from_the_cache = () => map.was_told_to(x => x.evict(id));

        //it should_mark_the_item_for_deletion_when_the_transaction_is_committed = () => transaction.was_told_to(x => x.mark_for_deletion(entity));

        context c = () =>
                        {
                            id = Guid.NewGuid();
                            entity = an<ITestEntity>();
                            map = an<IIdentityMap<Guid, ITestEntity>>();

                            when_the(entity).is_told_to(x => x.id).it_will_return(id);
                            when_the(transaction).is_told_to(x => x.create_for<ITestEntity>()).it_will_return(map);
                            when_the(database).is_told_to(x => x.fetch_all<ITestEntity>()).it_will_return(entity);
                        };

        because b = () =>
                        {
                            sut.find<ITestEntity>(id);
                            sut.delete(entity);
                        };

        static Guid id;
        static IIdentityMap<Guid, ITestEntity> map;
        static ITestEntity entity;
    }

    public interface ITestEntity : IIdentifiable<Guid>
    {
    }
}
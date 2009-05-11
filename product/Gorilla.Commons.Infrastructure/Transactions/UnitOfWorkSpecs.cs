using developwithpassion.bdd.contexts;
using Gorilla.Commons.Testing;

namespace Gorilla.Commons.Infrastructure.Transactions
{
    public class UnitOfWorkSpecs
    {
    }

    [Concern(typeof (UnitOfWork))]
    public abstract class behaves_like_unit_of_work : concerns_for<IUnitOfWork, UnitOfWork>
    {
        context c = () =>
                        {
                            session_context = the_dependency<IContext>();
                            session = the_dependency<ISession>();
                            key = the_dependency<IKey<ISession>>();
                        };

        static protected IContext session_context;
        static protected ISession session;
        static protected IKey<ISession> key;
    }

    [Concern(typeof (UnitOfWork))]
    public abstract class when_a_unit_of_work_has_unsaved_changes : behaves_like_unit_of_work
    {
        context c = () => when_the(session).is_told_to(x => x.is_dirty()).it_will_return(true);
    }

    [Concern(typeof (UnitOfWork))]
    public abstract class when_a_unit_of_work_has_no_changes : behaves_like_unit_of_work
    {
        context c = () => when_the(session).is_told_to(x => x.is_dirty()).it_will_return(false);
    }

    [Concern(typeof (UnitOfWork))]
    public class when_checking_if_a_unit_of_work_has_any_unsaved_changes : when_a_unit_of_work_has_unsaved_changes
    {
        it should_return_true = () => result.should_be_true();
        because b = () => { result = sut.is_dirty(); };
        static bool result;
    }

    [Concern(typeof (UnitOfWork))]
    public class when_commiting_a_unit_of_work : when_a_unit_of_work_has_unsaved_changes
    {
        it should_flush_the_current_session = () => session.was_told_to(x => x.flush());
        because b = () => sut.commit();
    }

    [Concern(typeof (UnitOfWork))]
    public class when_attempting_to_commit_a_unit_of_work : when_a_unit_of_work_has_no_changes
    {
        it should_not_flush_the_session = () => session.was_not_told_to(x => x.flush());
        because b = () => sut.commit();
    }

    [Concern(typeof (UnitOfWork))]
    public class when_disposing_of_a_unit_of_work : behaves_like_unit_of_work
    {
        it should_dispose_the_session = () => session.was_told_to(x => x.Dispose());
        it should_remove_the_session_from_the_current_context = () => session_context.was_told_to(x => x.remove(key));
        because b = () => sut.Dispose();
    }
}
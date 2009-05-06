using developwithpassion.bdd.contexts;
using Gorilla.Commons.Testing;

namespace Gorilla.Commons.Infrastructure.Transactions
{
    public class SessionFactorySpecs
    {
    }

    public class when_creating_a_new_session : concerns_for<ISessionFactory, SessionFactory>
    {
        it should_return_a_new_session = () => result.should_not_be_null();

        because b = () => { result = sut.create(); };

        static ISession result;
    }
}
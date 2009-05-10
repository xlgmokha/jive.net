using System.Collections;
using developwithpassion.bdd.contexts;
using Gorilla.Commons.Testing;

namespace Gorilla.Commons.Infrastructure.Transactions
{
    public class ContextFactorySpecs
    {
    }

    [Concern(typeof (ContextFactory))]
    public class when_creating_a_new_context : concerns_for<IContextFactory, ContextFactory>
    {
        context c = () =>
                        {
                            scope = an<IScopedStorage>();
                            storage = an<IDictionary>();

                            when_the(scope).is_told_to(x => x.provide_storage()).it_will_return(storage);
                        };

        because b = () => { result = sut.create_for(scope); };

        it should_return_a_context_that_represents_the_specified_scope =
            () => result.should_be_an_instance_of<Context>();

        static IDictionary storage;
        static IScopedStorage scope;
        static IContext result;
    }
}
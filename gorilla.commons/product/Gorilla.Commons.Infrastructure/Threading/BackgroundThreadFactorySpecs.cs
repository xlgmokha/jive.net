using developwithpassion.bdd.contexts;
using Gorilla.Commons.Infrastructure.Container;
using Gorilla.Commons.Testing;
using MoMoney.Utility.Core;

namespace Gorilla.Commons.Infrastructure.Threading
{
    [Concern(typeof (BackgroundThreadFactory))]
    public abstract class behaves_like_a_background_thread_factory : concerns_for<IBackgroundThreadFactory, BackgroundThreadFactory>
    {
        context c = () => { registry = the_dependency<IDependencyRegistry>(); };

        protected static IDependencyRegistry registry;
    }

    public class when_creating_a_background_thread : behaves_like_a_background_thread_factory
    {
        it should_return_an_instance_of_a_background_thread = () => result.should_not_be_null();

        it should_lookup_an_instance_of_the_command_to_execute =
            () => registry.was_told_to(r => r.get_a<IDisposableCommand>());

        because b = () => { result = sut.create_for<IDisposableCommand>(); };

        static IBackgroundThread result;
    }
}
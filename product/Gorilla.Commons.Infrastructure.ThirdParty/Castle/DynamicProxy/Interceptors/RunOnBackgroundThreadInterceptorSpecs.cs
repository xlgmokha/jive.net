using Castle.Core.Interceptor;
using developwithpassion.bdd.contexts;
using Gorilla.Commons.Infrastructure.Threading;
using Gorilla.Commons.Testing;
using MoMoney.Utility.Core;

namespace Gorilla.Commons.Infrastructure.Castle.DynamicProxy.Interceptors
{
    [Concern(typeof (RunOnBackgroundThreadInterceptor<>))]
    public abstract class behaves_like_background_thread_interceptor :
        concerns_for<IInterceptor, RunOnBackgroundThreadInterceptor<IDisposableCommand>>
    {
        context c = () => { thread_factory = the_dependency<IBackgroundThreadFactory>(); };

        static protected IBackgroundThreadFactory thread_factory;
    }

    [Concern(typeof (RunOnBackgroundThreadInterceptor<>))]
    public class when_intercepting_a_call_to_a_method_that_takes_a_long_time_to_complete :
        behaves_like_background_thread_interceptor
    {
        context c = () =>
                        {
                            invocation = an<IInvocation>();
                            background_thread = an<IBackgroundThread>();
                            thread_factory
                                .is_told_to(f => f.create_for<IDisposableCommand>())
                                .it_will_return(background_thread);
                        };

        because b = () => sut.Intercept(invocation);

        it should_display_a_progress_bar_on_a_background_thread =
            () => thread_factory.was_told_to(f => f.create_for<IDisposableCommand>());

        it should_proceed_with_the_orginal_invocation_on_the_actual_object =
            () => invocation.was_told_to(i => i.Proceed());

        it should_hide_the_progress_bar_when_the_invocation_is_completed =
            () => background_thread.was_told_to(b => b.Dispose());

        static IInvocation invocation;
        static IBackgroundThread background_thread;
    }
}
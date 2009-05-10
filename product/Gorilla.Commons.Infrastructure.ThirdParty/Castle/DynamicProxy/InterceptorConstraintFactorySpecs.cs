using developwithpassion.bdd.contexts;
using Gorilla.Commons.Testing;

namespace Gorilla.Commons.Infrastructure.Castle.DynamicProxy
{
    [Concern(typeof (InterceptorConstraintFactory))]
    public abstract class behaves_like_constraint_factory :
        concerns_for<IInterceptorConstraintFactory, InterceptorConstraintFactory>
    {
        context c = () => { method_call_tracker_factory = the_dependency<IMethodCallTrackerFactory>(); };

        protected static IMethodCallTrackerFactory method_call_tracker_factory;
    }

    [Concern(typeof (InterceptorConstraintFactory))]
    public class when_creating_a_constraint_for_a_type_to_intercept_on : behaves_like_constraint_factory
    {
        static IInterceptorConstraint<string> result;

        it should_create_a_method_call_tracker_for_the_type_to_place_a_constraint_on =
            () => method_call_tracker_factory.was_told_to(f => f.create_for<string>());

        it should_return_an_instance_of_an_interceptor_constraint =
            () => result.should_be_an_instance_of<InterceptorConstraint<string>>();

        because b = () => { result = sut.CreateFor<string>(); };
    }
}
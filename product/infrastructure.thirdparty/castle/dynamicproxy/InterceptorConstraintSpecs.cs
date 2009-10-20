using System.Collections.Generic;
using developwithpassion.bdd.contexts;
using gorilla.commons.infrastructure.thirdparty.Castle.DynamicProxy.Interceptors;
using Gorilla.Commons.Testing;

namespace gorilla.commons.infrastructure.thirdparty.Castle.DynamicProxy
{
    [Concern(typeof (CastleDynamicInterceptorConstraint<>))]
    public abstract class behaves_like_constraint : concerns_for<InterceptorConstraint<string>, CastleDynamicInterceptorConstraint<string>>
    {
        context c = () => { method_call_tracker = the_dependency<MethodCallTracker<string>>(); };

        protected static MethodCallTracker<string> method_call_tracker;
    }

    [Concern(typeof (CastleDynamicInterceptorConstraint<>))]
    public class when_asking_for_all_the_methods_to_intercept : behaves_like_constraint
    {
        static IEnumerable<string> result;
        static IList<string> methods_to_intercept;

        it should_return_all_the_recorded_method_calls_from_the_call_tracker =
            () => result.should_be_equal_to(methods_to_intercept);

        context c = () =>
        {
            methods_to_intercept = new List<string>();
            method_call_tracker
                .is_told_to(t => t.methods_to_intercept())
                .it_will_return(methods_to_intercept);
        };

        because b = () => { result = sut.methods_to_intercept(); };
    }

    [Concern(typeof (CastleDynamicInterceptorConstraint<int>))]
    public class when_asking_for_the_target_of_the_interception_constrain :
        concerns_for<InterceptorConstraint<int>, CastleDynamicInterceptorConstraint<int>>
    {
        static MethodCallTracker<int> method_call_tracker;
        static int result;
        const int target_of_interception = 7;

        context c = () =>
        {
            method_call_tracker = the_dependency<MethodCallTracker<int>>();
            method_call_tracker.is_told_to(t => t.target).it_will_return(target_of_interception);
        };

        because b = () => { result = sut.intercept_on; };

        it should_return_the_target_of_the_method_call_tracker =
            () => result.should_be_equal_to(target_of_interception);
    }
}
using System.Collections.Generic;
using System.Linq;
using Castle.Core.Interceptor;
using developwithpassion.bdd.contexts;
using Gorilla.Commons.Testing;

namespace gorilla.commons.infrastructure.thirdparty.Castle.DynamicProxy.Interceptors
{
    [Concern(typeof (CastleDynamicMethodCallTracker<>))]
    public class behaves_like_method_call_tracker :
        concerns_for<MethodCallTracker<IAnInterface>, CastleDynamicMethodCallTracker<IAnInterface>>
    {
        public override MethodCallTracker<IAnInterface> create_sut()
        {
            return new CastleDynamicMethodCallTracker<IAnInterface>();
        }
    }

    [Concern(typeof (CastleDynamicMethodCallTracker<>))]
    public class when_tracking_the_calls_to_intercept_on_a_type : behaves_like_method_call_tracker
    {
        static IInvocation invocation;
        static IEnumerable<string> result;

        context c = () =>
        {
            invocation = an<IInvocation>();
            invocation
                .is_told_to(s => s.Method)
                .it_will_return(typeof (IAnInterface).GetMethod("ValueReturningMethodWithAnArgument"));
        };

        because b = () =>
        {
            sut.Intercept(invocation);
            result = sut.methods_to_intercept();
        };

        it should_return_all_the_methods_that_are_specified_for_interception =
            () => result.should_contain(typeof (IAnInterface).GetMethod("ValueReturningMethodWithAnArgument").Name);

        it should_only_contain_the_methods_specified_for_interception = () => result.Count().should_be_equal_to(1);

        it should_specify_the_default_return_value_for_the_method_to_intercept =
            //() => invocation.was_told_to(i => i.ReturnValue = 0);
            () => invocation.ReturnValue.should_be_equal_to(0);
    }
}
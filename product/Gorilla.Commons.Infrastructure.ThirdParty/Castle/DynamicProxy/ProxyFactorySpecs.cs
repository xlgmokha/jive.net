using System;
using System.Data;
using Castle.Core.Interceptor;
using developwithpassion.bdd.contexts;
using developwithpassion.bdd.mbunit;
using Gorilla.Commons.Testing;

namespace Gorilla.Commons.Infrastructure.Castle.DynamicProxy
{
    [Concern(typeof(ProxyFactory))]
    public abstract class behaves_like_proxy_factory : concerns_for<IProxyFactory, ProxyFactory>
    {
        public override IProxyFactory create_sut()
        {
            return new ProxyFactory();
        }
    }

    [Concern(typeof(ProxyFactory))]
    public class when_creating_a_proxy_with_a_target : behaves_like_proxy_factory
    {
        it should_forward_all_calls_to_the_target = () => target.was_told_to(x => x.Open());

        it should_return_a_proxy_to_the_target = () =>
                                                     {
                                                         AssertionExtensions.should_not_be_null(result);
                                                         result.GetType().should_not_be_equal_to(target.GetType());
                                                     };

        it should_allow_the_interceptors_to_intercept_all_calls =
            () => AssertionExtensions.should_be_true(interceptor.recieved_call);

        context c = () => { target = the_dependency<IDbConnection>(); };

        because b = () =>
                        {
                            interceptor = new TestInterceptor();
                            result = sut.create_proxy_for(() => target, interceptor);
                            result.Open();
                        };

        static IDbConnection target;
        static IDbConnection result;
        static TestInterceptor interceptor;
    }

    [Concern(typeof(ProxyFactory))]
    public class when_creating_a_proxy_of_a_target_but_a_call_has_not_been_made_to_the_proxy_yet :
        behaves_like_proxy_factory
    {
        it should_not_create_an_instance_of_the_target = () => AssertionExtensions.should_be_false(TestClass.was_created);

        context c = TestClass.reset;

        because b = () => { result = sut.create_proxy_for<IDisposable>(() => new TestClass()); };

        after_each_observation ae = TestClass.reset;

        static IDisposable result;
    }

    [Concern(typeof(ProxyFactory))]
    public class when_creating_a_proxy_of_a_component_that_does_not_implement_an_interface : behaves_like_proxy_factory
    {
        it should_return_a_proxy = () => AssertionExtensions.should_not_be_null(result);

        because b = () => { result = sut.create_proxy_for(() => new ClassWithNoInterface()); };

        after_each_observation ae = TestClass.reset;

        static ClassWithNoInterface result;
    }

    public class ClassWithNoInterface
    {
    }

    public class TestClass : IDisposable
    {
        public static bool was_created;

        public TestClass()
        {
            was_created = true;
        }

        public static void reset()
        {
            was_created = false;
        }

        public void Dispose()
        {
        }
    }

    public class TestInterceptor : IInterceptor
    {
        public bool recieved_call { get; set; }

        public void Intercept(IInvocation invocation)
        {
            recieved_call = true;
            invocation.Proceed();
        }
    }
}
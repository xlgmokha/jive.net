using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Castle.Core.Interceptor;
using developwithpassion.bdd.contexts;
using Gorilla.Commons.Testing;

namespace Gorilla.Commons.Infrastructure.Castle.DynamicProxy
{
    [Concern(typeof (ProxyBuilder<IAnInterface>))]
    public class behaves_like_proxy_builder : concerns_for<IProxyBuilder<IAnInterface>, ProxyBuilder<IAnInterface>>
    {
        public override IProxyBuilder<IAnInterface> create_sut()
        {
            return new ProxyBuilder<IAnInterface>();
        }
    }

    public class when_building_a_proxy_for_a_type : behaves_like_proxy_builder
    {
        it should_make_sure_the_original_call_gets_forwarded_to_the_item_to_proxy =
            () =>
                {
                    an_implementation_of_the_interface.was_told_to(i => i.OneMethod());
                    an_implementation_of_the_interface.was_told_to(i => i.SecondMethod());
                };

        it should_allow_each_intercepter_to_intercept_the_call =
            () =>
                {
                    SomeInterceptor.MethodsCalled.Count().should_be_equal_to(2);
                    AnotherInterceptor.MethodsCalled.Count().should_be_equal_to(2);
                };

        context c = () => { an_implementation_of_the_interface = an<IAnInterface>(); };

        because b = () =>
                        {
                            sut.add_interceptor<SomeInterceptor>();
                            sut.add_interceptor<AnotherInterceptor>();
                            var proxy = sut.create_proxy_for(() => an_implementation_of_the_interface);
                            proxy.OneMethod();
                            proxy.SecondMethod();
                        };

        after_each_observation ae = () =>
                                        {
                                            SomeInterceptor.Cleanup();
                                            AnotherInterceptor.Cleanup();
                                        };

        static IAnInterface an_implementation_of_the_interface;
    }

    [Integration]
    public class when_building_a_proxy_to_target_certain_methods_on_a_type : behaves_like_proxy_builder
    {
        it should_only_intercept_calls_on_the_method_that_was_specified =
            () =>
                {
                    SomeInterceptor.MethodsCalled.Count().should_be_equal_to(1);
                    SomeInterceptor.MethodsCalled.First().Name.should_be_equal_to("OneMethod");
                };

        context c = () => { an_implementation = an<IAnInterface>(); };

        because b = () =>
                        {
                            var constraint = sut.add_interceptor<SomeInterceptor>();
                            constraint.intercept_on.OneMethod();

                            var proxy = sut.create_proxy_for(() => an_implementation);
                            proxy.OneMethod();
                            proxy.SecondMethod();
                        };

        after_each_observation ae = () =>
                                        {
                                            SomeInterceptor.Cleanup();
                                            AnotherInterceptor.Cleanup();
                                        };

        static IAnInterface an_implementation;
    }

    public class when_proxying_all_calls_on_a_target : behaves_like_proxy_builder
    {
        it should_intercept_each_call =
            () =>
                {
                    SomeInterceptor.MethodsCalled.Count().should_be_equal_to(3 );
                    SomeInterceptor.MethodsCalled.First().Name.should_be_equal_to("OneMethod");
                    SomeInterceptor.MethodsCalled.Skip(1).First().Name.should_be_equal_to("SecondMethod");
                    SomeInterceptor.MethodsCalled.Skip(2).First().Name.should_be_equal_to("region");
                };

        context c = () => { an_implementation = an<IAnInterface>(); };

        because b = () =>
                        {
                            var constraint = sut.add_interceptor<SomeInterceptor>();
                            constraint.intercept_all();

                            var proxy = sut.create_proxy_for(() => an_implementation);
                            proxy.OneMethod();
                            proxy.SecondMethod();
                            proxy.region(() => "mo");
                        };

        after_each_observation ae = () =>
                                        {
                                            SomeInterceptor.Cleanup();
                                            AnotherInterceptor.Cleanup();
                                        };

        static IAnInterface an_implementation;
    }

    public interface IAnInterface
    {
        string GetterAndSetterProperty { get; set; }
        void OneMethod();
        void SecondMethod();
        int FirstValueReturningMethod();
        int ValueReturningMethodWithAnArgument(int number);
        void region<T>(Func<T> call);
    }

    public class SomeInterceptor : IInterceptor
    {
        public static bool WasCalled;
        public static IList<MethodInfo> MethodsCalled;

        static SomeInterceptor()
        {
            MethodsCalled = new List<MethodInfo>();
        }

        public void Intercept(IInvocation invocation)
        {
            WasCalled = true;
            MethodsCalled.Add(invocation.Method);
            invocation.Proceed();
        }

        public static void Cleanup()
        {
            WasCalled = false;
            MethodsCalled.Clear();
        }
    }

    public class AnotherInterceptor : IInterceptor
    {
        public static bool WasCalled;
        public static IList<MethodInfo> MethodsCalled;

        static AnotherInterceptor()
        {
            MethodsCalled = new List<MethodInfo>();
        }

        public void Intercept(IInvocation invocation)
        {
            WasCalled = true;
            MethodsCalled.Add(invocation.Method);
            invocation.Proceed();
        }

        public static void Cleanup()
        {
            WasCalled = false;
            MethodsCalled.Clear();
        }
    }

    public class SomeImplementation : IAnInterface
    {
        public string GetterAndSetterProperty { get; set; }

        public void OneMethod()
        {
        }

        public void SecondMethod()
        {
        }

        public int FirstValueReturningMethod()
        {
            return 1;
        }

        public int ValueReturningMethodWithAnArgument(int number)
        {
            return number + 1;
        }

        public void region<T>(Func<T> call)
        {
        }
    }
}
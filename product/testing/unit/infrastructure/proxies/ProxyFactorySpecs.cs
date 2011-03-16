using Gorilla.Commons.Infrastructure.Proxies;
using Gorilla.Commons.Testing;
using Machine.Specifications;

namespace gorilla.commons.testing.unit.infrastructure.proxies
{
    public class ProxyFactorySpecs
    {
        [Concern(typeof (ProxyFactory))]
        public class when_proxying_a_class_with_interceptors_applied
        {
            Establish c = () =>
            {
                interceptors = new MyNameIsSlimShadyInterceptor();
                marshal_mathers = new Person("marshall mathers");
            };

            Because b =
                () =>
                {
                    some_celebrity = ProxyFactory.create<IPerson>(marshal_mathers, interceptors);
                };

            It should_all_each_interceptor_to_intercept_the_invocation =
                () => some_celebrity.what_is_your_name().should_be_equal_to("slim shady");

            static Person marshal_mathers;
            static IPerson some_celebrity;
            static Interceptor interceptors;
        }

        public interface IPerson
        {
            string what_is_your_name();
        }

        public class Person : IPerson
        {
            readonly string my_name;

            public Person(string my_name)
            {
                this.my_name = my_name;
            }

            public string what_is_your_name()
            {
                return my_name;
            }
        }

        public class MyNameIsSlimShadyInterceptor : Interceptor
        {
            public void intercept(Invocation invocation)
            {
                invocation.proceed();
                invocation.return_value = "slim shady";
            }
        }
    }
}
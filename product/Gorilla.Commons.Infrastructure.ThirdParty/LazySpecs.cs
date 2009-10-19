using developwithpassion.bdd.contexts;
using Gorilla.Commons.Infrastructure.Container;
using Gorilla.Commons.Testing;

namespace Gorilla.Commons.Infrastructure
{
    [Concern(typeof (Lazy))]
    public abstract class behaves_like_a_lazy_loaded_object : concerns
    {
        context c = () =>
                        {
                            test_container = dependency<DependencyRegistry>();
                            Resolve.initialize_with(test_container);
                        };

        after_each_observation a = () => Resolve.initialize_with(null);

        protected static DependencyRegistry test_container;
    }

    [Concern(typeof (Lazy))]
    public class when_calling_a_method_with_no_arguments_on_a_lazy_loaded_proxy : behaves_like_a_lazy_loaded_object
    {
        it should_forward_the_original_call_to_the_target = () => target.was_told_to<ITargetObject>(t => t.OneMethod());

        context c = () =>
                        {
                            target = an<ITargetObject>();
                            test_container.is_told_to(t => t.get_a<ITargetObject>()).it_will_return(target).Repeat.Once();
                        };

        because b = () =>
                        {
                            var result = Lazy.load<ITargetObject>();
                            result.OneMethod();
                        };

        static ITargetObject target;
    }

    [Concern(typeof (Lazy))]
    public class when_calling_a_method_that_returns_an_argument_on_a_lazy_loaded_proxy :
        behaves_like_a_lazy_loaded_object
    {
        it should_return_the_value_from_the_actual_target = () => result.should_be_equal_to(10);

        context c = () =>
                        {
                            var target = an<ITargetObject>();

                            target.is_told_to(x => x.FirstValueReturningMethod()).it_will_return(10);
                            test_container.is_told_to(t => t.get_a<ITargetObject>()).it_will_return(target) .Repeat.Once();
                        };

        because b = () =>
                        {
                            var proxy = Lazy.load<ITargetObject>();
                            result = proxy.FirstValueReturningMethod();
                        };

        static int result;
    }

    [Concern(typeof (Lazy))]
    public class when_calling_different_methods_on_an_proxied_object : behaves_like_a_lazy_loaded_object
    {
        it should_only_load_the_object_once =
            () => test_container.was_told_to(x => x.get_a<ITargetObject>()).only_once();

        context c = () =>
                        {
                            var target = an<ITargetObject>();
                            test_container.is_told_to(t => t.get_a<ITargetObject>()).it_will_return(target).Repeat.Once();
                        };

        because b = () =>
                        {
                            var proxy = Lazy.load<ITargetObject>();
                            proxy.SecondMethod();
                            proxy.FirstValueReturningMethod();
                        };
    }

    [Concern(typeof (Lazy))]
    public class when_calling_a_method_that_takes_in_a_single_input_parameter_on_a_proxied_object :
        behaves_like_a_lazy_loaded_object
    {
        it should_forward_the_call_to_the_original_target =
            () => target.was_told_to(x => x.ValueReturningMethodWithAnArgument(88));

        it should_return_the_correct_result = () => result.should_be_equal_to(99);

        context c = () =>
                        {
                            target = an<ITargetObject>();

                            target.is_told_to(x => x.ValueReturningMethodWithAnArgument(88)).it_will_return(99);
                            test_container.is_told_to(t => t.get_a<ITargetObject>()).it_will_return(target).Repeat.Once();
                        };

        because b = () =>
                        {
                            var proxy = Lazy.load<ITargetObject>();
                            result = proxy.ValueReturningMethodWithAnArgument(88);
                        };

        static ITargetObject target;
        static int result;
    }

    [Concern(typeof (Lazy))]
    public class when_accessing_the_value_of_a_property_on_a_proxied_object : behaves_like_a_lazy_loaded_object
    {
        it should_return_the_correct_value = () => result.should_be_equal_to("mo");

        context c = () =>
                        {
                            var target = an<ITargetObject>();

                            target.GetterAndSetterProperty = "mo";
                            test_container.is_told_to(t => t.get_a<ITargetObject>()).it_will_return(target).Repeat.Once();
                        };

        because b = () =>
                        {
                            var proxy = Lazy.load<ITargetObject>();
                            result = proxy.GetterAndSetterProperty;
                        };

        static string result;
    }

    [Concern(typeof (Lazy))]
    public class when_setting_the_value_of_a_property_on_a_proxied_object : behaves_like_a_lazy_loaded_object
    {
        it should_set_the_value_on_the_original_target =
            () => target.was_told_to(x => x.GetterAndSetterProperty = "khan");

        context c = () =>
                        {
                            target = dependency<ITargetObject>();
                            test_container.is_told_to(t => t.get_a<ITargetObject>()).it_will_return(target) .Repeat.Once();
                        };

        because b = () =>
                        {
                            var proxy = Lazy.load<ITargetObject>();
                            proxy.GetterAndSetterProperty = "khan";
                        };

        static ITargetObject target;
    }

    [Concern(typeof (Lazy))]
    public class when_calling_a_generic_method_on_a_proxied_object : behaves_like_a_lazy_loaded_object
    {
        it should_forward_the_call_to_the_target =
            () => target.was_told_to(x => x.ValueReturningMethodWithAnArgument("blah"));

        it should_return_the_correct_result = () => result.should_be_equal_to("hooray");

        context c = () =>
                        {
                            target = an<IGenericInterface<string>>();

                            target.is_told_to(x => x.ValueReturningMethodWithAnArgument("blah")).it_will_return("hooray");
                            test_container.is_told_to(t => t.get_a<IGenericInterface<string>>()).it_will_return(target).Repeat.Once();
                        };

        because b = () =>
                        {
                            var proxy = Lazy.load<IGenericInterface<string>>();
                            result = proxy.ValueReturningMethodWithAnArgument("blah");
                        };

        static IGenericInterface<string> target;
        static string result;
    }

    public interface IGenericInterface<T>
    {
        T GetterAndSetterProperty { get; set; }
        void OneMethod();
        void SecondMethod();
        T FirstValueReturningMethod();
        T ValueReturningMethodWithAnArgument(T item);
    }

    public interface ITargetObject
    {
        string GetterAndSetterProperty { get; set; }
        void OneMethod();
        void SecondMethod();
        int FirstValueReturningMethod();
        int ValueReturningMethodWithAnArgument(int number);
    }
}
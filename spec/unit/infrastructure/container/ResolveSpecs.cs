using System;
using gorilla.infrastructure.container;
using gorilla.utility;
using Machine.Specifications;

namespace specs.unit.infrastructure.container
{
    [Subject(typeof (Resolve))]
    public abstract class behaves_like_a_inversion_of_control_container
    {
        [Subject(typeof (Resolve))]
        public class when_resolving_a_dependency_using_the_container : behaves_like_a_inversion_of_control_container
        {
            Establish c = () =>
            {
                registry = Create.an<DependencyRegistry>();
                presenter = Create.an<Command>();
                registry.is_told_to(x => x.get_a<Command>()).it_will_return(presenter);
                Resolve.initialize_with(registry);
            };

            Because b = () =>
            {
                result = Resolve.the<Command>();
            };

            It should_leverage_the_underlying_container_it_was_initialized_with =
                () => registry.was_told_to(x => x.get_a<Command>());

            It should_return_the_resolved_dependency = () => result.should_be_equal_to(presenter);

            Cleanup a = () => Resolve.initialize_with(null);

            static DependencyRegistry registry;
            static Command result;
            static Command presenter;
        }

        [Subject(typeof (Resolve))]
        public class when_resolving_a_dependency_that_is_not_registered_ : behaves_like_a_inversion_of_control_container
        {
            Establish c = () =>
            {
                registry = Create.an<DependencyRegistry>();
                registry.is_told_to(x => x.get_a<Command>()).it_will_throw(new Exception());
                Resolve.initialize_with(registry);
            };

            Because b = () =>
            {
                the_call = call.to(() => Resolve.the<Command>());
            };

            Cleanup a = () => Resolve.initialize_with(null);

            It should_throw_a_dependency_resolution_exception = () => the_call.should_have_thrown<DependencyResolutionException<Command>>();

            static DependencyRegistry registry;
            static Action the_call;
        }
    }
}
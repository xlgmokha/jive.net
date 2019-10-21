using System;
using jive.infrastructure.container;
using jive.utility;
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
        registry.Setup(x => x.get_a<Command>()).Returns(presenter.Object);
        Resolve.initialize_with(registry.Object);
      };

      Because b = () =>
      {
        result = Resolve.the<Command>();
      };

      It should_leverage_the_underlying_container_it_was_initialized_with =
        () => registry.Verify(x => x.get_a<Command>());

      It should_return_the_resolved_dependency = () => result.should_be_equal_to(presenter.Object);

      Cleanup a = () => Resolve.initialize_with(null);

      static Moq.Mock<DependencyRegistry> registry;
      static Command result;
      static Moq.Mock<Command> presenter;
    }

    [Subject(typeof (Resolve))]
    public class when_resolving_a_dependency_that_is_not_registered_ : behaves_like_a_inversion_of_control_container
    {
      Establish c = () =>
      {
        registry = Create.an<DependencyRegistry>();
        registry.Setup(x => x.get_a<Command>()).Throws(new Exception());
        Resolve.initialize_with(registry.Object);
      };

      Because b = () =>
      {
        the_call = call.to(() => Resolve.the<Command>());
      };

      Cleanup a = () => Resolve.initialize_with(null);

      It should_throw_a_dependency_resolution_exception = () => the_call.should_have_thrown<DependencyResolutionException<Command>>();

      static Moq.Mock<DependencyRegistry> registry;
      static Action the_call;
    }
  }
}

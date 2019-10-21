using System.Collections.Generic;
using jive;
using Machine.Specifications;

namespace specs.unit
{
  [Subject(typeof (DefaultRegistry<int>))]
  public class when_retrieving_all_the_items_from_the_default_repository
  {
    It should_leverage_the_resolver_to_retrieve_all_the_implementations =
      () => registry.Verify(r => r.get_all<int>());

    It should_return_the_items_resolved_by_the_registry = () => result.should_contain(24);

    Establish c = () =>
    {
      var items_to_return = new List<int> {24};
      registry = Create.an<DependencyRegistry>();
      registry.Setup(r => r.get_all<int>()).Returns(items_to_return);
      sut = create_sut();
    };

    static Registry<int> create_sut()
    {
      return new DefaultRegistry<int>(registry.Object);
    }

    Because b = () =>
    {
      result = sut.all();
    };

    static Moq.Mock<DependencyRegistry> registry;
    static IEnumerable<int> result;
    static Registry<int> sut;
  }
}

using System.Collections.Generic;
using Gorilla.Commons.Infrastructure.Container;
using Gorilla.Commons.Infrastructure.Registries;
using Gorilla.Commons.Testing;
using gorilla.commons.utility;
using Machine.Specifications;

namespace gorilla.commons.testing.unit.infrastructure.registries
{
    [Subject(typeof (DefaultRegistry<int>))]
    public class when_retrieving_all_the_items_from_the_default_repository
    {
        It should_leverage_the_resolver_to_retrieve_all_the_implementations =
            () => registry.was_told_to(r => r.get_all<int>());

        It should_return_the_items_resolved_by_the_registry = () => result.should_contain(24);

        Establish c = () =>
        {
            var items_to_return = new List<int> {24};
            registry = Create.an<DependencyRegistry>();
            registry.is_told_to(r => r.get_all<int>()).it_will_return(items_to_return);
            sut = create_sut();
        };

        static Registry<int> create_sut()
        {
            return new DefaultRegistry<int>(registry);
        }

        Because b = () =>
        {
            result = sut.all();
        };

        static DependencyRegistry registry;
        static IEnumerable<int> result;
        static Registry<int> sut;
    }
}
using System.Collections.Generic;
using developwithpassion.bdd.contexts;
using Gorilla.Commons.Infrastructure.Container;
using Gorilla.Commons.Testing;
using gorilla.commons.utility;

namespace Gorilla.Commons.Infrastructure.Registries
{
    [Concern(typeof (DefaultRegistry<int>))]
    public class when_retrieving_all_the_items_from_the_default_repository :
        concerns_for<Registry<int>, DefaultRegistry<int>>
    {
        it should_leverage_the_resolver_to_retrieve_all_the_implementations =
            () => registry.was_told_to(r => r.get_all<int>());

        it should_return_the_items_resolved_by_the_registry = () => result.should_contain(24);

        context c = () =>
                        {
                            var items_to_return = new List<int> {24};
                            registry = an<DependencyRegistry>();
                            registry.is_told_to(r => r.get_all<int>()).it_will_return(items_to_return);
                        };

        public override Registry<int> create_sut()
        {
            return new DefaultRegistry<int>(registry);
        }

        because b = () => { result = sut.all(); };

        static DependencyRegistry registry;
        static IEnumerable<int> result;
    }
}
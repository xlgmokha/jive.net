using System.Collections.Generic;
using developwithpassion.bdd.contexts;
using Gorilla.Commons.Infrastructure.Container;
using Gorilla.Commons.Testing;
using Gorilla.Commons.Utility.Core;

namespace Gorilla.Commons.Infrastructure.Registries
{
    [Concern(typeof (DefaultRegistry<int>))]
    public class when_retrieving_all_the_items_from_the_default_repository :
        concerns_for<IRegistry<int>, DefaultRegistry<int>>
    {
        it should_leverage_the_resolver_to_retrieve_all_the_implementations =
            () => registry.was_told_to(r => r.all_the<int>());

        it should_return_the_items_resolved_by_the_registry = () => result.should_contain(24);

        context c = () =>
                        {
                            var items_to_return = new List<int> {24};
                            registry = an<IDependencyRegistry>();
                            registry.is_told_to(r => r.all_the<int>()).it_will_return(items_to_return);
                        };

        public override IRegistry<int> create_sut()
        {
            return new DefaultRegistry<int>(registry);
        }

        because b = () => { result = sut.all(); };

        static IDependencyRegistry registry;
        static IEnumerable<int> result;
    }
}
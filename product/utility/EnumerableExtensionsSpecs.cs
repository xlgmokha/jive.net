using System.Collections.Generic;
using developwithpassion.bdd.contexts;
using Gorilla.Commons.Testing;

namespace gorilla.commons.utility
{
    public class EnumerableExtensionsSpecs
    {
        [Concern(typeof (EnumerableExtensions))]
        public class when_joining_one_collection_with_another : concerns
        {
            it should_return_the_items_from_both = () =>
            {
                results.should_contain(1);
                results.should_contain(2);
            };

            because b = () =>
            {
                results = new List<int> {1}.join_with(new List<int> {2});
            };

            static IEnumerable<int> results;
        }

        [Concern(typeof (EnumerableExtensions))]
        public class when_attemping_to_join_a_list_with_a_null_value : concerns
        {
            it should_return_the_original_list = () => new List<int> {1}.join_with(null).should_contain(1);
        }
    }
}
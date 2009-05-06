using System.Collections.Generic;
using developwithpassion.bdd.contexts;
using Gorilla.Commons.Testing;

namespace Gorilla.Commons.Utility.Extensions
{
    public class when_adding_an_item_to_a_list : concerns
    {
        because b = () =>
                        {
                            list = new List<string>();
                            list.add("mo");
                        };

        it should_add_the_item_to_the_list = () => list.should_contain("mo");

        static List<string> list;
    }

    public abstract class when_asked_to_only_add_an_item_to_a_list_if_a_condition_is_not_met : concerns
    {
        context c = () => { list = new List<string>(); };

        static protected List<string> list;
    }

    public class when_the_condition_is_not_met : when_asked_to_only_add_an_item_to_a_list_if_a_condition_is_not_met
    {
        because b = () => list.add("mo").unless(x => false);

        it should_add_the_item_to_the_list = () => list.should_contain("mo");
    }

    public class when_the_condition_is_met : when_asked_to_only_add_an_item_to_a_list_if_a_condition_is_not_met
    {
        because b = () => list.add("mo").unless(x => true);

        it should_not_add_the_item_to_the_list = () => list.should_not_contain("mo");
    }

    public class when_some_of_the_items_meet_the_conditions_and_some_do_not :
        when_asked_to_only_add_an_item_to_a_list_if_a_condition_is_not_met
    {
        because b = () => list
                              .add_range(new List<string> {"mo", "khan"})
                              .unless(x => x.Equals("mo"));

        it should_add_the_items_that_do_not_meet_the_condition = () =>
                                                                     {
                                                                         list.Count.should_be_equal_to(1);
                                                                         list.should_contain("khan");
                                                                     };

        it should_not_add_the_items_that_do_meet_the_condition = () => list.should_not_contain("mo");
    }

    public class ListExtensionsSpecs
    {
    }
}
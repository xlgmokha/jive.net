using developwithpassion.bdd.contexts;
using Gorilla.Commons.Testing;

namespace Gorilla.Commons.Infrastructure.Transactions
{
    [Concern(typeof (IdentityMap<,>))]
    public class behaves_like_identity_map : concerns_for<IIdentityMap<int, string>, IdentityMap<int, string>>
    {
        public override IIdentityMap<int, string> create_sut()
        {
            return new IdentityMap<int, string>();
        }
    }

    [Concern(typeof (IdentityMap<,>))]
    public class when_getting_an_item_from_the_identity_map_for_an_item_that_has_been_added : behaves_like_identity_map
    {
        it should_return_the_item_that_was_added_for_the_given_key = () => result.should_be_equal_to("1");

        because b = () =>
                        {
                            sut.add(1, "1");
                            result = sut.item_that_belongs_to(1);
                        };

        static string result;
    }

    [Concern(typeof (IdentityMap<,>))]
    public class when_getting_an_item_from_the_identity_map_that_has_not_been_added : behaves_like_identity_map
    {
        it should_return_the_default_value_for_that_type = () => result.should_be_equal_to(null);

        because b = () => { result = sut.item_that_belongs_to(2); };

        static string result;
    }

    [Concern(typeof (IdentityMap<,>))]
    public class when_checking_if_an_item_has_been_added_to_the_identity_map_that_has_been_added :
        behaves_like_identity_map
    {
        it should_return_true = () => result.should_be_true();

        because b = () =>
                        {
                            sut.add(10, "10");
                            result = sut.contains_an_item_for(10);
                        };

        static bool result;
    }

    [Concern(typeof (IdentityMap<,>))]
    public class when_checking_if_an_item_has_been_added_to_the_identity_map_that_has_not_been_added :
        behaves_like_identity_map
    {
        it should_return_false = () => result.should_be_false();

        because b = () => { result = sut.contains_an_item_for(9); };

        static bool result;
    }

    [Concern(typeof (IdentityMap<,>))]
    public class when_updating_the_value_for_a_key_that_has_already_been_added_to_the_identity_map :
        behaves_like_identity_map
    {
        it should_replace_the_old_item_with_the_new_one = () => result.should_be_equal_to("7");

        because b = () =>
                        {
                            sut.add(6, "6");
                            sut.update_the_item_for(6, "7");
                            result = sut.item_that_belongs_to(6);
                        };

        static string result;
    }

    [Concern(typeof (IdentityMap<,>))]
    public class when_updating_the_value_for_a_key_that_has_not_been_added_to_the_identity_map :
        behaves_like_identity_map
    {
        it should_add_the_new_item = () => result.should_be_equal_to("3");

        because b = () =>
                        {
                            sut.update_the_item_for(3, "3");
                            result = sut.item_that_belongs_to(3);
                        };

        static string result;
    }
}
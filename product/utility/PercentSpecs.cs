using developwithpassion.bdd.contexts;
using Gorilla.Commons.Testing;

namespace Gorilla.Commons.Utility
{
    [Concern(typeof (Percent))]
    public class when_comparing_fifty_divided_by_one_hundred_to_fifty_percent : concerns
    {
        it they_should_be_equal = () => new Percent(50, 100).should_be_equal_to<Percent>(50);
    }

    [Concern(typeof (Percent))]
    public class when_calculating_a_fractional_percentage : concerns
    {
        it should_return_the_correct_percentage = () => new Percent(30, 90).should_be_equal_to<Percent>(33.3);
    }

    [Concern(typeof (Percent))]
    public class when_checking_if_50_percent_is_less_than_51_percent : concerns
    {
        it should_return_true = () => new Percent(50).is_less_than(new Percent(51)).should_be_true();
    }

    [Concern(typeof (Percent))]
    public class when_checking_if_51_percent_is_less_than_50_percent : concerns
    {
        it should_return_false = () => new Percent(51).is_less_than(new Percent(50)).should_be_false();
    }

    [Concern(typeof (Percent))]
    public class when_checking_if_50_percent_is_less_than_50_percent : concerns
    {
        it should_return_false = () => new Percent(50).is_less_than(new Percent(50)).should_be_false();
    }
}
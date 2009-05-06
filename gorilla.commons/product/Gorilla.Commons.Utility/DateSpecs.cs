using developwithpassion.bdd.contexts;
using Gorilla.Commons.Testing;

namespace Gorilla.Commons.Utility
{
    public class DateSpecs
    {
    }

    [Concern(typeof (Date))]
    public class when_two_dates_that_represent_the_same_day_are_asked_if_they_are_equal : concerns_for<Date>
    {
        it should_return_true = () => result.should_be_equal_to(true);

        public override Date create_sut()
        {
            return new Date(2008, 09, 25);
        }

        because b = () => { result = sut.Equals(new Date(2008, 09, 25)); };

        static bool result;
    }

    [Concern(typeof (Date))]
    public class when_an_older_date_is_compared_to_a_younger_date : concerns_for<Date>
    {
        it should_return_a_positive_number = () => result.should_be_greater_than(0);

        public override Date create_sut()
        {
            return new Date(2008, 09, 25);
        }

        because b = () => { result = sut.CompareTo(new Date(2007, 01, 01)); };

        static int result;
    }
}
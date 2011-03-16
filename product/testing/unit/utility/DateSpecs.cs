using gorilla.utility;
using Machine.Specifications;

namespace specs.unit.utility
{
    public class DateSpecs
    {
        [Subject(typeof (Date))]
        public class when_two_dates_that_represent_the_same_day_are_asked_if_they_are_equal
        {
            It should_return_true = () => result.should_be_equal_to(true);

            Because b = () =>
            {
                result = new Date(2008, 09, 25).Equals(new Date(2008, 09, 25));
            };

            static bool result;
        }

        [Subject(typeof (Date))]
        public class when_an_older_date_is_compared_to_a_younger_date
        {
            It should_return_a_positive_number = () => result.should_be_greater_than(0);

            Because b = () =>
            {
                result = new Date(2008, 09, 25).CompareTo(new Date(2007, 01, 01));
            };

            static int result;
        }
    }
}
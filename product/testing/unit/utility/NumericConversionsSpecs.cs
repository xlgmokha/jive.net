using Gorilla.Commons.Testing;
using gorilla.commons.utility;
using Machine.Specifications;

namespace gorilla.commons.testing.unit.utility
{
    [Subject(typeof (NumericConversions))]
    public class when_converting_a_valid_string_to_a_long
    {
        It should_return_the_correct_result = () => result.should_be_equal_to(88L);

        Establish c = () => { valid_numeric_string = "88"; };

        Because b = () => { result = valid_numeric_string.to_long(); };

        static long result;
        static string valid_numeric_string;
    }

    [Subject(typeof (NumericConversions))]
    public class when_converting_a_valid_string_to_an_int 
    {
        It should_return_the_correct_result = () => result.should_be_equal_to(66);

        Establish c = () => { valid_numeric_string = "66"; };

        Because b = () => { result = valid_numeric_string.to_int(); };

        static int result;
        static string valid_numeric_string;
    }
}
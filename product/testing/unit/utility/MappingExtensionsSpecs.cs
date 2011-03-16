using Gorilla.Commons.Testing;
using gorilla.commons.utility;
using Machine.Specifications;

namespace gorilla.commons.testing.unit.utility
{
    [Concern(typeof (MappingExtensions))]
    public class when_transforming_type_A_to_type_B_then_C
    {
        It should_return_the_correct_result = () => result.should_be_equal_to(1);

        Establish c = () =>
        {
            first_mapper = Create.an<Mapper<object, string>>();
            second_mapper = Create.an<Mapper<string, int>>();
            a = 1;

            first_mapper.is_told_to(x => x.map_from(a)).it_will_return("1");
            second_mapper.is_told_to(x => x.map_from("1")).it_will_return(1);
        };

        Because b = () =>
        {
            result = first_mapper.then(second_mapper).map_from(a);
        };


        static int result;
        static Mapper<object, string> first_mapper;
        static Mapper<string, int> second_mapper;
        static object a;
    }
}
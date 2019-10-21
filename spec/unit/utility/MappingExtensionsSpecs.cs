using jive.utility;
using Machine.Specifications;

namespace specs.unit.utility
{
  [Subject(typeof (MappingExtensions))]
  public class when_transforming_type_A_to_type_B_then_C
  {
    It should_return_the_correct_result = () => result.should_be_equal_to(1);

    Establish c = () =>
    {
      first_mapper = Create.an<Mapper<object, string>>();
      second_mapper = Create.an<Mapper<string, int>>();
      a = 1;

      first_mapper.Setup(x => x.map_from(a)).Returns("1");
      second_mapper.Setup(x => x.map_from("1")).Returns(1);
    };

    Because b = () =>
    {
      result = first_mapper.Object.then(second_mapper.Object).map_from(a);
    };


    static int result;
    static Moq.Mock<Mapper<object, string>> first_mapper;
    static Moq.Mock<Mapper<string, int>> second_mapper;
    static object a;
  }
}

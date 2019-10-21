using jive;
using Machine.Specifications;

namespace specs.unit.utility
{
  public class TypeExtensionsSpecs
  {
    [Subject(typeof (TypeExtensions))]
    public class when_getting_the_last_interface_for_a_type
    {
      It should_return_the_correct_one =
        () => typeof (TestType).last_interface().should_be_equal_to(typeof (ITestType));
    }

    [Subject(typeof (TypeExtensions))]
    public class when_getting_the_first_interface_for_a_type
    {
      It should_return_the_correct_one = () => typeof (TestType).first_interface().should_be_equal_to(typeof (IBase));
    }

    [Subject(typeof (TypeExtensions))]
    public class when_checking_if_a_type_represents_a_generic_type_definition
    {
      It should_tell_the_truth = () =>
      {
        typeof (Registry<>).is_a_generic_type().should_be_true();
        typeof (Registry<int>).is_a_generic_type().should_be_false();
      };
    }

    public interface IBase {}

    public class BaseType : IBase {}

    public interface ITestType {}

    public class TestType : BaseType, ITestType {}
  }
}

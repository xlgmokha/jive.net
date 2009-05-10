using developwithpassion.bdd.contexts;
using Gorilla.Commons.Testing;
using Gorilla.Commons.Utility.Core;

namespace Gorilla.Commons.Utility.Extensions
{
    [Concern(typeof (TypeExtensions))]
    public class when_getting_the_last_interface_for_a_type : concerns
    {
        it should_return_the_correct_one =
            () => typeof (TestType).last_interface().should_be_equal_to(typeof (ITestType));
    }

    [Concern(typeof (TypeExtensions))]
    public class when_getting_the_first_interface_for_a_type : concerns
    {
        it should_return_the_correct_one = () => typeof (TestType).first_interface().should_be_equal_to(typeof (IBase));
    }

    [Concern(typeof (TypeExtensions))]
    public class when_checking_if_a_type_represents_a_generic_type_definition : concerns
    {
        it should_tell_the_truth = () => { 
                                             typeof (IRegistry<>).is_a_generic_type().should_be_true();
                                             typeof (IRegistry<int>).is_a_generic_type().should_be_false();
        };
    }

    public interface IBase
    {
    }

    public class BaseType : IBase
    {
    }

    public interface ITestType
    {
    }

    public class TestType : BaseType, ITestType
    {
    }
}
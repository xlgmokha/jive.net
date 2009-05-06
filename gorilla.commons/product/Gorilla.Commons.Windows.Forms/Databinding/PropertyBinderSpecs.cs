using System.Reflection;
using developwithpassion.bdd.contexts;
using Gorilla.Commons.Testing;

namespace Gorilla.Commons.Windows.Forms.Databinding
{
    [Concern(typeof (PropertyBinder<IAnInterface, string>))]
    public abstract class behaves_like_a_property_binder :
        concerns_for<IPropertyBinder<IAnInterface, string>, PropertyBinder<IAnInterface, string>>
    {
        public override IPropertyBinder<IAnInterface, string> create_sut()
        {
            return new PropertyBinder<IAnInterface, string>(property, target);
        }

        context c = () =>
                        {
                            target = new AnImplementation {FirstName = "malik"};
                            property = typeof (IAnInterface).GetProperty("FirstName");
                        };

        static protected IAnInterface target;
        static protected PropertyInfo property;
    }

    public class when_changing_the_value_of_correctly_bound_property : behaves_like_a_property_binder
    {
        it should_update_the_value_of_the_property_of_the_target_of_the_binder =
            () => target.FirstName.should_be_equal_to(first_name);

        because b = () => sut.change_value_of_property_to(first_name);

        const string first_name = "mo";
    }

    public class when_retrieving_the_current_value_of_a_bound_property : behaves_like_a_property_binder
    {
        it should_return_the_correct_value = () => result.should_be_equal_to("malik");

        because b = () => { result = sut.current_value(); };

        static string result;
    }

    public class PropertyBinderSpecs
    {
    }
}
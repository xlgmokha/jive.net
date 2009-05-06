using System.Reflection;
using developwithpassion.bdd.contexts;
using Gorilla.Commons.Testing;

namespace Gorilla.Commons.Windows.Forms.Databinding
{
    [Concern(typeof (PropertyInspector<IAnInterface, string>))]
    public class when_parsing_a_valie_expression_for_the_information_on_the_property :
        concerns_for<IPropertyInspector<IAnInterface, string>, PropertyInspector<IAnInterface, string>>
    {
        it should_return_the_correct_property_information = () => result.Name.should_be_equal_to("FirstName");

        because b = () => { result = sut.inspect(s => s.FirstName); };

        public override IPropertyInspector<IAnInterface, string> create_sut()
        {
            return new PropertyInspector<IAnInterface, string>();
        }

        static PropertyInfo result;
    }

    public class PropertyInspectorSpecs
    {
    }
}
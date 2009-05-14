using System.Windows.Forms;
using developwithpassion.bdd.contexts;
using Gorilla.Commons.Testing;

namespace Gorilla.Commons.Windows.Forms.Databinding
{
    public class CreateSpecs
    {
    }

    public abstract class when_a_text_control_is_bound_to_an_item : concerns
    {
        context c = () =>
                        {
                            textbox = new TextBox();
                            item = new TestItem {name = "k"};
                            textbox.bind_to(item, x => x.name);
                        };

        static protected TextBox textbox;
        static protected TestItem item;
    }

    public class when_the_value_of_a_text_control_changes : when_a_text_control_is_bound_to_an_item
    {
        it should_update_the_value_of_the_property_on_the_item = () => item.name.should_be_equal_to("mo");
        because b = () => { textbox.Text = "mo"; };
    }

    public class TestItem
    {
        public string name { get; set; }
    }
}
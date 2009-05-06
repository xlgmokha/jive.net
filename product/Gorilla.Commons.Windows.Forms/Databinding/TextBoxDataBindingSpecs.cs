using System.Windows.Forms;
using developwithpassion.bdd.contexts;
using Gorilla.Commons.Testing;

namespace Gorilla.Commons.Windows.Forms.Databinding
{
    [Concern(typeof (Create))]
    public class when_binding_a_property_on_an_object_to_a_textbox : concerns
    {
        it should_initialize_the_text_of_the_textbox_to_the_value_of_the_property =
            () => text_box.Text.should_be_equal_to(first_name);

        context c = () =>
                        {
                            thing_to_bind_to = an<IAnInterface>();
                            text_box = new TextBox();
                            thing_to_bind_to.is_asked_for(t => t.FirstName).it_will_return(first_name);
                        };

        because b = () => Create
                              .binding_for(thing_to_bind_to)
                              .bind_to_property(t => t.FirstName)
                              .bound_to_control(text_box);

        static TextBox text_box;
        static IAnInterface thing_to_bind_to;
        static string first_name = "mO";
    }

    [Concern(typeof (Create))]
    public class when_updating_the_text_of_a_bound_text_box : concerns
    {
        it should_update_the_value_of_the_property_that_the_textbox_is_bound_to =
            () => thing_to_bind_to.FirstName.should_be_equal_to(expected_name);

        context c = () =>
                        {
                            thing_to_bind_to = new AnImplementation {FirstName = "abshir"};
                            text_box = new TextBox();

                            Create
                                .binding_for(thing_to_bind_to)
                                .bind_to_property(t => t.FirstName)
                                .bound_to_control(text_box);
                        };

        because b = () => { text_box.Text = expected_name; };

        static TextBox text_box;
        static IAnInterface thing_to_bind_to;
        static string expected_name = "ugo";
    }

    public interface IAnInterface
    {
        string FirstName { get; }
        IAnInterface Child { get; }
    }

    public class AnImplementation : IAnInterface
    {
        public string FirstName { get; set; }
        public IAnInterface Child { get; set; }
    }
}
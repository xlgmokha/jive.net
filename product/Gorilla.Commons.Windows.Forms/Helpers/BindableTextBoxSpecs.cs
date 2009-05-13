using developwithpassion.bdd.contexts;
using Gorilla.Commons.Testing;
using Gorilla.Commons.Utility.Core;
using Gorilla.Commons.Utility.Extensions;

namespace Gorilla.Commons.Windows.Forms.Helpers
{
    public class BindableTextBoxSpecs
    {
    }

    [Concern(typeof (BindableTextBox<>))]
    public class concerns_for_text_box : concerns_for<IBindableTextBox<string>, BindableTextBox<string>>
    {
        context c = () => { control = the_dependency<ITextControl<string>>(); };

        static protected ITextControl<string> control;
    }

    [Concern(typeof (BindableTextBox<>))]
    public class when_binding_an_item_to_a_textbox : concerns_for_text_box
    {
        it should_change_the_text_of_the_text_control = () => control.was_told_to(x => x.set_selected_item("shrek"));

        because b = () => sut.bind_to("shrek");
    }

    [Concern(typeof (BindableTextBox<>))]
    public class when_getting_the_current_value_of_a_text_box : concerns_for_text_box
    {
        it should_return_the_current_value_of_the_text_box = () => result.should_be_equal_to("popeye");

        context c = () => when_the(control).is_told_to(x => x.get_selected_item()).it_will_return("popeye");
        because b = () => { result = sut.get_selected_value(); };

        static string result;
    }

    [Concern(typeof (BindableTextBox<>))]
    public class when_an_action_needs_to_be_performed_when_the_value_of_a_textbox_changes : concerns_for_text_box
    {
        it should_perform_that_action = () => action.was_told_to(x => x.run());

        context c = () => { action = an<ICommand>(); };

        because b = () =>
                        {
                            sut.on_leave(x => action.run());
                            control.when_text_is_changed();
                        };

        static ICommand action;
    }
}
using System;
using System.Windows.Forms;
using developwithpassion.bdd.contexts;
using Gorilla.Commons.Testing;
using Gorilla.Commons.Utility.Core;

namespace Gorilla.Commons.Windows.Forms.Helpers
{
    public class TextControlSpecs
    {
    }

    [Concern(typeof (TextControl<>))]
    public abstract class behaves_like_text_control : concerns_for<ITextControl<DateTime>, TextControl<DateTime>>
    {
        context c = () => { textbox = new TextBox(); };

        public override ITextControl<DateTime> create_sut()
        {
            return new TextControl<DateTime>(textbox);
        }

        static protected TextBox textbox;
    }

    [Concern(typeof (TextControl<>))]
    public class when_a_text_control_is_bound_to_an_item : behaves_like_text_control
    {
        it should_display_the_textual_version_of_the_item = () => textbox.Text.should_be_equal_to(date.ToString());

        it should_bind_to_that_item = () => sut.get_selected_item().should_be_equal_to(date);

        context c = () => { date = new DateTime(1984, 04, 28); };

        because b = () => sut.set_selected_item(date);

        static DateTime date;
    }

    [Concern(typeof (TextControl<>))]
    public class when_the_text_changes_on_a_text_control_and_action_is_specified : behaves_like_text_control
    {
        it should_invoke_the_action_bound_to_it = () => action.was_told_to(x => x.run());

        context c = () => { action = an<ICommand>(); };

        because b = () =>
                        {
                            sut.when_text_is_changed = () => action.run();
                            textbox.control_is(x => x.OnLeave(new EventArgs()));
                        };

        static ICommand action;
    }

    [Concern(typeof (TextControl<>))]
    public class when_the_text_changes_on_a_text_control_and_action_is_not_specified : behaves_like_text_control
    {
        it should_not_blow_up = () => { };

        because b = () => textbox.control_is(x => x.OnLeave(new EventArgs()));
    }
}
using System;
using System.Windows.Forms;
using developwithpassion.bdd.contexts;
using Gorilla.Commons.Testing;

namespace Gorilla.Commons.Windows.Forms.Helpers
{
    [Concern(typeof (EventTrigger))]
    public class when_invoking_a_call_on_a_target_via_reflection : concerns
    {
        it should_correctly_call_that_method =
            () =>
                {
                    control.called_on_key_press.should_be_true();
                    control.called_on_enter.should_be_false();
                };

        context c = () => { control = new TestControl(); };

        because b =
            () =>
            EventTrigger.trigger_event<Events.ControlEvents>(x => x.OnKeyPress(new KeyPressEventArgs('A')), control);

        static TestControl control;
    }

    [Concern(typeof (EventTrigger))]
    public class when_invoking_a_call_on_a_target_by_passing_in_a_parameter : concerns
    {
        it should_make_the_call_correctly = () => control.key_press_arguments.should_be_equal_to(args);

        //[Test]
        //public void should_make_the_call_correctly2()
        //{
        //    var new_args = new KeyPressEventArgs('A');
        //    control = new TestControl();
        //    EventTrigger.trigger_event<Events.ControlEvents>(x => x.OnKeyPress(new_args), control);
        //    control.key_press_arguments.should_be_equal_to(new_args);
        //}

        context c = () => { control = new TestControl(); };

        because b = () => EventTrigger.trigger_event<Events.ControlEvents>(x => x.OnKeyPress(args), control);

        static TestControl control;

        static readonly KeyPressEventArgs args = new KeyPressEventArgs('A');
    }

    internal class TestControl
    {
        public bool called_on_enter;
        public bool called_on_key_press;
        public KeyPressEventArgs key_press_arguments;

        protected void OnEnter(EventArgs args)
        {
            called_on_enter = true;
        }

        protected void OnKeyPress(KeyPressEventArgs args)
        {
            called_on_key_press = true;
            key_press_arguments = args;
        }
    }
}
using System;
using System.Windows.Forms;
using developwithpassion.bdd.contexts;
using Gorilla.Commons.Testing;

namespace Gorilla.Commons.Windows.Forms.Databinding
{
    [Concern(typeof (Create))]
    public class when_a_new_date_is_selected_by_a_date_time_picker_that_is_bound_to_a_property : concerns
    {
        it should_update_the_value_of_the_property =
            () => Assertions.should_be_equal_to(thing_to_bind_to.birth_day, november_nineteenth);

        context c = () =>
                        {
                            date_time_picker = new DateTimePicker {Value = DateTime.Now};
                            thing_to_bind_to = new TestDTO {birth_day = DateTime.Now};

                            Create.binding_for(thing_to_bind_to)
                                .bind_to_property(x => x.birth_day)
                                .bound_to_control(date_time_picker);
                        };

        because b = () => { date_time_picker.Value = november_nineteenth; };

        static DateTimePicker date_time_picker;
        static TestDTO thing_to_bind_to;
        static readonly DateTime november_nineteenth = new DateTime(2006, 11, 19);
    }

    public class TestDTO
    {
        public DateTime birth_day { get; set; }
    }

    public class DateTimePropertyBindingSpecs
    {
    }
}
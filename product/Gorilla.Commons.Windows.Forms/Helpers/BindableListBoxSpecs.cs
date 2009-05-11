using System.Collections.Generic;
using developwithpassion.bdd.contexts;
using Gorilla.Commons.Testing;

namespace Gorilla.Commons.Windows.Forms.Helpers
{
    public class BindableListBoxSpecs
    {
    }

    public class behaves_like_bindable_list : concerns_for<IBindableList<string>, BindableListBox<string>>
    {
        context c = () => { control = the_dependency<IListControl<string>>(); };

        static protected IListControl<string> control;
    }

    public class when_binding_a_bunch_of_items_to_a_list_control : behaves_like_bindable_list
    {
        it should_add_each_item_to_the_list_control = () =>
                                                          {
                                                              control.was_told_to(x => x.add_item("timone"));
                                                              control.was_told_to(x => x.add_item("pumba"));
                                                          };

        because b = () => sut.bind_to(new List<string> {"timone", "pumba",});
    }

    public class when_assigning_the_selected_item_of_a_list_control : behaves_like_bindable_list
    {
        it should_tell_the_list_control_to_select_that_item =
            () => control.was_told_to(x => x.set_selected_item("arthur"));

        because b = () => sut.set_selected_item("arthur");
    }

    public class when_getting_the_selected_item_from_a_list_control : behaves_like_bindable_list
    {
        it should_return_the_selected_item = () => result.should_be_equal_to("curious george");
        context c = () => when_the(control).is_told_to(x => x.get_selected_item()).it_will_return("curious george");
        because b = () => { result = sut.get_selected_item(); };

        static string result;
    }
}
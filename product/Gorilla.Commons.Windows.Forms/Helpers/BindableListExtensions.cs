using System.Windows.Forms;

namespace Gorilla.Commons.Windows.Forms.Helpers
{
    static public class BindableListExtensions
    {
        static public IBindableList<TItemToBindTo> create_for<TItemToBindTo>(this ListBox listbox)
        {
            return BindableListFactory.create_for(new ListBoxListControl<TItemToBindTo>(listbox));
        }

        static public IBindableList<TItemToBindTo> create_for<TItemToBindTo>(this ComboBox combobox)
        {
            return BindableListFactory.create_for(new ComboBoxListControl<TItemToBindTo>(combobox));
        }
    }
}
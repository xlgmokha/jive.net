using ComponentFactory.Krypton.Toolkit;
using Gorilla.Commons.Windows.Forms.Helpers;

namespace Gorilla.Commons.Windows.Forms.Krypton
{
    static public class BindableListExtensions
    {
        static public IBindableList<TItemToBindTo> create_for<TItemToBindTo>(this KryptonListBox listbox)
        {
            return BindableListFactory.create_for(new KryptonListBoxListControl<TItemToBindTo>(listbox));
        }

        static public IBindableList<TItemToBindTo> create_for<TItemToBindTo>(this KryptonComboBox combobox)
        {
            return BindableListFactory.create_for(new KryptonComboBoxListControl<TItemToBindTo>(combobox));
        }
    }
}
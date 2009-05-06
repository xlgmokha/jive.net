using ComponentFactory.Krypton.Toolkit;
using Gorilla.Commons.Windows.Forms.Helpers;

namespace Gorilla.Commons.Windows.Forms.Krypton
{
    public class KryptonListBoxListControl<TItemToStore> : IListControl<TItemToStore>
    {
        readonly KryptonListBox list_box;

        public KryptonListBoxListControl(KryptonListBox list_box)
        {
            this.list_box = list_box;
        }

        public TItemToStore get_selected_item()
        {
            return (TItemToStore) list_box.SelectedItem;
        }

        public void add_item(TItemToStore item)
        {
            list_box.Items.Add(item);
        }

        public void set_selected_item(TItemToStore item)
        {
            if (list_box.Items.Contains(item)) list_box.SelectedItem = item;
        }
    }
}
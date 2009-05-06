using System.Windows.Forms;

namespace Gorilla.Commons.Windows.Forms.Helpers
{
    public class ListBoxListControl<TItemToStore> : IListControl<TItemToStore>
    {
        readonly ListBox list_box;

        public ListBoxListControl(ListBox list_box)
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
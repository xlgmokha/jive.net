using System.Windows.Forms;

namespace Gorilla.Commons.Windows.Forms.Helpers
{
    public class ComboBoxListControl<TItemToStore> : IListControl<TItemToStore>
    {
        readonly ComboBox combo_box;

        public ComboBoxListControl(ComboBox combo_box)
        {
            this.combo_box = combo_box;
        }

        public TItemToStore get_selected_item()
        {
            return (TItemToStore) combo_box.SelectedItem;
        }

        public void add_item(TItemToStore item)
        {
            combo_box.Items.Add(item);
            combo_box.SelectedIndex = 0;
        }

        public void set_selected_item(TItemToStore item)
        {
            if (!Equals(item, default(TItemToStore)))
                if (combo_box.Items.Contains(item)) combo_box.SelectedItem = item;
        }
    }
}
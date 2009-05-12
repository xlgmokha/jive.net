using System.Collections.Generic;

namespace Gorilla.Commons.Windows.Forms.Helpers
{
    public interface IBindableList<ItemToBindTo>
    {
        void bind_to(IEnumerable<ItemToBindTo> items);
        ItemToBindTo get_selected_item();
        void set_selected_item(ItemToBindTo item);
    }
}
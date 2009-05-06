using System.Collections.Generic;

namespace Gorilla.Commons.Windows.Forms.Helpers
{
    public interface IBindableList<TItemToBindTo>
    {
        void bind_to(IEnumerable<TItemToBindTo> items);
        TItemToBindTo get_selected_item();
        void set_selected_item(TItemToBindTo item);
    }
}
using System.Collections.Generic;
using Gorilla.Commons.Utility.Extensions;

namespace Gorilla.Commons.Windows.Forms.Helpers
{
    public class BindableListBox<TItemToBindTo> : IBindableList<TItemToBindTo>
    {
        readonly IListControl<TItemToBindTo> list_control;

        public BindableListBox(IListControl<TItemToBindTo> list_control)
        {
            this.list_control = list_control;
        }

        public void bind_to(IEnumerable<TItemToBindTo> items)
        {
            items.each(x => list_control.add_item(x));
        }

        public TItemToBindTo get_selected_item()
        {
            return list_control.get_selected_item();
        }

        public void set_selected_item(TItemToBindTo item)
        {
            list_control.set_selected_item(item);
        }
    }
}
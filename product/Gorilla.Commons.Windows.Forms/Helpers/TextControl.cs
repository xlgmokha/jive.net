using System;
using System.Windows.Forms;

namespace Gorilla.Commons.Windows.Forms.Helpers
{
    public class TextControl<ItemToStore> : ITextControl<ItemToStore>
    {
        readonly TextBox textbox;
        ItemToStore selected_item;

        public TextControl(TextBox textbox)
        {
            this.textbox = textbox;
            when_text_is_changed = () => { };
            textbox.Leave += (sender, args) => when_text_is_changed();
        }

        public void set_selected_item(ItemToStore item)
        {
            textbox.Text = item.ToString();
            selected_item = item;
        }

        public ItemToStore get_selected_item()
        {
            return selected_item;
        }

        public string text()
        {
            return textbox.Text;
        }

        public Action when_text_is_changed { get; set; }
    }
}
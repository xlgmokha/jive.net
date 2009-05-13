using System;
using ComponentFactory.Krypton.Toolkit;
using Gorilla.Commons.Windows.Forms.Helpers;

namespace Gorilla.Commons.Windows.Forms.Krypton
{
    public class KryptonTextControl<T> : ITextControl<T>
    {
        readonly KryptonTextBox textbox;
        T bound_item;

        public KryptonTextControl(KryptonTextBox textbox)
        {
            this.textbox = textbox;
            when_text_is_changed = () => { };
            textbox.TextChanged += (sender, args) => when_text_is_changed();
        }

        public void set_selected_item(T item)
        {
            textbox.Text = item.ToString();
            bound_item = item;
        }

        public T get_selected_item()
        {
            return bound_item;
        }

        public string text()
        {
            return textbox.Text;
        }

        public Action when_text_is_changed { get; set; }
    }
}
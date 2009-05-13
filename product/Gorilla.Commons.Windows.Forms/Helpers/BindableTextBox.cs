using System;
using System.Collections.Generic;
using Gorilla.Commons.Utility.Extensions;

namespace Gorilla.Commons.Windows.Forms.Helpers
{
    public interface IBindableTextBox<T>
    {
        void bind_to(T item);
        T get_selected_value();
        string text();
        void on_leave(Action<IBindableTextBox<T>> action);
    }

    public class BindableTextBox<T> : IBindableTextBox<T>
    {
        readonly ITextControl<T> control;
        readonly IList<Action<IBindableTextBox<T>>> actions = new List<Action<IBindableTextBox<T>>>();

        public BindableTextBox(ITextControl<T> control)
        {
            this.control = control;
            control.when_text_is_changed = () => actions.each(x => x(this));
        }

        public void bind_to(T item)
        {
            control.set_selected_item(item);
        }

        public T get_selected_value()
        {
            return control.get_selected_item();
        }

        public string text()
        {
            return control.text();
        }

        public void on_leave(Action<IBindableTextBox<T>> action)
        {
            actions.Add(action);
        }
    }
}
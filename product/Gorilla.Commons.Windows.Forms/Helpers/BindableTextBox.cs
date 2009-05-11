namespace Gorilla.Commons.Windows.Forms.Helpers
{
    public interface IBindableTextBox<T>
    {
        void bind_to(T item);
        T get_selected_value();
    }

    public class BindableTextBox<T> : IBindableTextBox<T>
    {
        readonly ITextControl<T> control;

        public BindableTextBox(ITextControl<T> control)
        {
            this.control = control;
        }

        public void bind_to(T item)
        {
            control.set_selected_item(item);
        }

        public T get_selected_value()
        {
            return control.get_selected_item();
        }
    }
}
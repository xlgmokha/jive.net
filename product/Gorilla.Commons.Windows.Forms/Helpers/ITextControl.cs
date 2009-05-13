namespace Gorilla.Commons.Windows.Forms.Helpers
{
    public interface ITextControl<ItemToStore>
    {
        void set_selected_item(ItemToStore item);
        ItemToStore get_selected_item();
        string text();
    }
}
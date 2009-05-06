namespace Gorilla.Commons.Windows.Forms.Databinding
{
    public interface IPropertyBinding<PropertyType>
    {
        PropertyType current_value();
    }
}
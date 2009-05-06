namespace Gorilla.Commons.Windows.Forms.Databinding
{
    public interface IPropertyInspectorFactory
    {
        IPropertyInspector<TypeToInspect, TypeOfProperty> create<TypeToInspect, TypeOfProperty>();
    }

    public class PropertyInspectorFactory : IPropertyInspectorFactory
    {
        public IPropertyInspector<TypeToInspect, TypeOfProperty> create<TypeToInspect, TypeOfProperty>()
        {
            return new PropertyInspector<TypeToInspect, TypeOfProperty>();
        }
    }
}
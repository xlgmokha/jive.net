using System;
using System.Linq.Expressions;

namespace Gorilla.Commons.Windows.Forms.Databinding
{
    public interface IBindingSelector<TypeToBindTo>
    {
        IPropertyBinder<TypeToBindTo, TypeOfProperty> bind_to_property<TypeOfProperty>(
            Expression<Func<TypeToBindTo, TypeOfProperty>> property_to_bind_to);
    }

    public class BindingSelector<TypeToBindTo> : IBindingSelector<TypeToBindTo>
    {
        private readonly TypeToBindTo thing_to_bind_to;
        private readonly IPropertyInspectorFactory factory;

        public BindingSelector(TypeToBindTo thing_to_bind_to, IPropertyInspectorFactory factory)
        {
            this.thing_to_bind_to = thing_to_bind_to;
            this.factory = factory;
        }

        public IPropertyBinder<TypeToBindTo, TypeOfProperty> bind_to_property<TypeOfProperty>(
            Expression<Func<TypeToBindTo, TypeOfProperty>> property_to_bind_to)
        {
            var property_information = factory.create<TypeToBindTo, TypeOfProperty>().inspect(property_to_bind_to);
            return new PropertyBinder<TypeToBindTo, TypeOfProperty>(property_information, thing_to_bind_to);
        }
    }
}
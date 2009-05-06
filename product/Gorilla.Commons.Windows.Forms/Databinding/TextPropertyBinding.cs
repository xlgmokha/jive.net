using System;
using System.Windows.Forms;
using Gorilla.Commons.Utility.Extensions;

namespace Gorilla.Commons.Windows.Forms.Databinding
{
    public class TextPropertyBinding<TypeToBindTo, PropertyType> : IPropertyBinding<PropertyType>
    {
        private readonly IPropertyBinder<TypeToBindTo, PropertyType> binder;

        public TextPropertyBinding(Control control, IPropertyBinder<TypeToBindTo, PropertyType> binder)
        {
            this.binder = binder;
            control.Text = "{0}".formatted_using(binder.current_value());
            control.TextChanged +=
                (o, e) => binder.change_value_of_property_to(control.Text.converted_to<PropertyType>());
        }

        public PropertyType current_value()
        {
            return binder.current_value();
        }
    }
}
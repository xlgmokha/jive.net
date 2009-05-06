using System;
using System.Windows.Forms;

namespace Gorilla.Commons.Windows.Forms.Databinding
{
    public static class ControlBindingExtensions
    {
        public static IPropertyBinding<PropertyType> bound_to_control<TypeToBindTo, PropertyType>(
            this IPropertyBinder<TypeToBindTo, PropertyType> binder,
            Control control)
        {
            return new TextPropertyBinding<TypeToBindTo, PropertyType>(control, binder);
        }

        public static IPropertyBinding<PropertyType> bound_to_control<TypeToBindTo, PropertyType>(
            this IPropertyBinder<TypeToBindTo, PropertyType> binder,
            ComboBox control)
        {
            return new ComboBoxPropertyBinding<TypeToBindTo, PropertyType>(control, binder);
        }

        public static IPropertyBinding<DateTime> bound_to_control<TypeToBindTo>(
            this IPropertyBinder<TypeToBindTo, DateTime> binder,
            DateTimePicker control)
        {
            return new DateTimePickerPropertyBinding<TypeToBindTo>(control, binder);
        }
    }
}
using System;
using System.Windows.Forms;

namespace Gorilla.Commons.Windows.Forms.Databinding
{
    public class DateTimePickerPropertyBinding<TypeToBindTo> : IPropertyBinding<DateTime>
    {
        private readonly IPropertyBinder<TypeToBindTo, DateTime> binder;

        public DateTimePickerPropertyBinding(DateTimePicker control, IPropertyBinder<TypeToBindTo, DateTime> binder)
        {
            this.binder = binder;
            control.ValueChanged += (o, e) => binder.change_value_of_property_to(control.Value);
        }

        public DateTime current_value()
        {
            return binder.current_value();
        }
    }
}
using System.Collections.Generic;
using System.Windows.Forms;
using Gorilla.Commons.Utility.Extensions;

namespace Gorilla.Commons.Windows.Forms.Databinding
{
    static public class ListboxExtensions
    {
        static public void bind_to<T>(this ComboBox control, IEnumerable<T> items)
        {
            control.Items.Clear();
            items.each(x => control.Items.Add(x));
        }
    }
}
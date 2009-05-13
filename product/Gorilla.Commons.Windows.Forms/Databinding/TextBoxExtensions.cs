using System.Windows.Forms;
using Gorilla.Commons.Windows.Forms.Helpers;

namespace Gorilla.Commons.Windows.Forms.Databinding
{
    static public class TextBoxExtensions
    {
        static public ITextControl<T> text_control<T>(this TextBox textbox)
        {
            return new TextControl<T>(textbox);
        }
    }
}
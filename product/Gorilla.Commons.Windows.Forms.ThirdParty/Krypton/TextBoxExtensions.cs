using ComponentFactory.Krypton.Toolkit;
using Gorilla.Commons.Windows.Forms.Helpers;

namespace Gorilla.Commons.Windows.Forms.Krypton
{
    static public class TextBoxExtensions
    {
        static public ITextControl<T> text_control<T>(this KryptonTextBox textbox)
        {
            return new KryptonTextControl<T>(textbox);
        }
    }
}
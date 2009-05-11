using Gorilla.Commons.Utility.Core;

namespace Gorilla.Commons.Windows.Forms.Helpers
{
    public interface ITextBoxCommand<T> : IParameterizedCommand<IBindableTextBox<T>>
    {
    }
}
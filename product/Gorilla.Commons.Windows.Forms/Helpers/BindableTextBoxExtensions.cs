using System;
using System.Linq.Expressions;
using Gorilla.Commons.Utility.Extensions;

namespace Gorilla.Commons.Windows.Forms.Helpers
{
    static public class BindableTextBoxExtensions
    {
        static public IBindableTextBox<ItemToBindTo> apply<ItemToBindTo>(this ITextControl<ItemToBindTo> text_control, params ITextBoxCommand<ItemToBindTo>[] commands)
        {
            var textbox = new BindableTextBox<ItemToBindTo>(text_control);
            commands.each(x => textbox.on_leave(y => x.run(y)));
            return textbox;
        }

        static public IBindableTextBox<ItemToBindTo> rebind_with<ItemToBindTo>(
            this ITextControl<ItemToBindTo> text_control, Expression<Func<string, ItemToBindTo>> rebind)
        {
            return text_control.apply(new RebindTextBoxCommand<ItemToBindTo>(rebind));
        }
    }
}
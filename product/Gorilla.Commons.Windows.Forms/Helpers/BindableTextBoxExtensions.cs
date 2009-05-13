using System;
using System.Linq.Expressions;
using Gorilla.Commons.Utility.Extensions;

namespace Gorilla.Commons.Windows.Forms.Helpers
{
    static public class BindableTextBoxExtensions
    {
        static public IBindableTextBox<ItemToBindTo> rebind_with<ItemToBindTo>(
            this ITextControl<ItemToBindTo> text_control, Expression<Func<string, ItemToBindTo>> rebind)
        {
            return text_control.apply(new RebindTextBoxCommand<ItemToBindTo>(rebind));
        }

        static public IBindableTextBox<ItemToBindTo> apply<ItemToBindTo>(this ITextControl<ItemToBindTo> text_control,
                                                                         params ITextBoxCommand<ItemToBindTo>[] commands)
        {
            return new BindableTextBox<ItemToBindTo>(text_control).apply(commands);
        }

        static public IBindableTextBox<ItemToBindTo> apply<ItemToBindTo>(this IBindableTextBox<ItemToBindTo> textbox,
                                                                         params ITextBoxCommand<ItemToBindTo>[] commands)
        {
            commands.each(x => textbox.on_leave(y => x.run(y)));
            return textbox;
        }
    }
}
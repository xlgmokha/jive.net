using System;
using System.Linq.Expressions;
using Gorilla.Commons.Utility.Extensions;

namespace Gorilla.Commons.Windows.Forms.Helpers
{
    static public class BindableTextBoxFactory
    {
        static public IBindableTextBox<ItemToBindTo> create_for<ItemToBindTo>(ITextControl<ItemToBindTo> text_control, params ITextBoxCommand<ItemToBindTo>[] commands)
        {
            var textbox = new BindableTextBox<ItemToBindTo>(text_control);
            commands.each(x => textbox.on_leave(y => x.run(y)));
            return textbox;
        }
    }

    static public class BindableTextBoxExtensions
    {
        static public IBindableTextBox<ItemToBindTo> rebind_with<ItemToBindTo>(
            this ITextControl<ItemToBindTo> text_control, Expression<Func<string, ItemToBindTo>> rebind)
        {
            return BindableTextBoxFactory.create_for(text_control, new RebindTextBoxCommand<ItemToBindTo>(rebind));
        }
    }
}
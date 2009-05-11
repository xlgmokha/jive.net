using System;
using System.Linq.Expressions;

namespace Gorilla.Commons.Windows.Forms.Helpers
{
    public class RebindTextBoxCommand<T> : ITextBoxCommand<T>
    {
        readonly Expression<Func<string, T>> binder;

        public RebindTextBoxCommand(Expression<Func<string, T>> binder)
        {
            this.binder = binder;
        }

        public void run(IBindableTextBox<T> item)
        {
            item.bind_to(binder.Compile()(item.text()));
        }
    }
}
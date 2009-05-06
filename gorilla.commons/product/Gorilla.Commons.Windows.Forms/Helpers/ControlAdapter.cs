using System;
using System.Windows.Forms;

namespace Gorilla.Commons.Windows.Forms.Helpers
{
    public class ControlAdapter : Control
    {
        readonly IDisposable item;

        public ControlAdapter(IDisposable item)
        {
            this.item = item;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) item.Dispose();
            base.Dispose(disposing);
        }
    }
}
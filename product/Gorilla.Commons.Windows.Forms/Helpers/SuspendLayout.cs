using System;
using System.Windows.Forms;

namespace Gorilla.Commons.Windows.Forms.Helpers
{
    public class SuspendLayout : IDisposable
    {
        readonly Control control;

        public SuspendLayout(Control control)
        {
            this.control = control;
            control.SuspendLayout();
        }

        public void Dispose()
        {
            control.ResumeLayout();
        }
    }
}
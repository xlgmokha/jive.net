using System;
using System.Windows.Forms;

namespace Gorilla.Commons.Windows.Forms.Helpers
{
    static public class ControlExtensions
    {
        static public IDisposable suspend_layout(this Control control)
        {
            return new SuspendLayout(control);
        }
    }
}
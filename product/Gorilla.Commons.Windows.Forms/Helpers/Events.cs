using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Gorilla.Commons.Windows.Forms.Helpers
{
    public class Events
    {
        public interface ControlEvents : IEventTarget
        {
            void OnEnter(EventArgs args);
            void OnKeyPress(KeyPressEventArgs args);
            void OnKeyUp(KeyEventArgs args);
            void OnKeyDown(KeyEventArgs args);
            void OnClick(EventArgs args);
            void OnDoubleClick(EventArgs args);
            void OnDragDrop(DragEventArgs args);
            void OnDragEnter(DragEventArgs args);
            void OnDragLeave(EventArgs args);
            void OnDragOver(DragEventArgs args);
            void OnMouseWheel(MouseEventArgs args);
            void OnValidated(EventArgs args);
            void OnValidating(CancelEventArgs args);
            void OnLeave(EventArgs args);
        }

        public interface FormEvents : ControlEvents
        {
            void OnActivated(EventArgs e);
            void OnDeactivate(EventArgs e);
            void OnClosed(EventArgs e);
            void OnClosing(CancelEventArgs e);
        }
    }
}
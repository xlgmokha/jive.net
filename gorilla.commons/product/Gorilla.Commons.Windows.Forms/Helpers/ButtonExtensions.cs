using System;
using System.Drawing;
using System.Windows.Forms;
using Gorilla.Commons.Infrastructure.Container;
using Gorilla.Commons.Utility.Core;

namespace Gorilla.Commons.Windows.Forms.Helpers
{
    static public class ButtonExtensions
    {
        static public Button will_be_shown_as(this Button button, Bitmap image)
        {
            BitmapRegion.CreateControlRegion(button, image);
            button.MouseLeave += (sender, e) => BitmapRegion.CreateControlRegion(button, image);
            button.FlatAppearance.BorderSize = 0; //needs to be here so edges don't get affected by borders
            return button;
        }

        static public Button when_hovered_over_will_show(this Button button, Bitmap image)
        {
            button.MouseEnter += (sender, e) => BitmapRegion.CreateControlRegion(button, image);
            return button;
        }

        static public Button will_execute<Command>(this Button button, Func<bool> when) where Command : ICommand
        {
            button.Click += (sender, e) => { if (when()) Resolve.the<Command>().run(); };
            button.Enabled = when();
            return button;
        }

        static public Control with_tool_tip(this Control control, string title, string caption)
        {
            var tip = new ToolTip
                          {
                              IsBalloon = true,
                              ToolTipTitle = title,
                              ToolTipIcon = ToolTipIcon.Info,
                              UseAnimation = true,
                              UseFading = true,
                              AutoPopDelay = 10000,
                          };
            tip.SetToolTip(control, caption);
            control.Controls.Add(new ControlAdapter(tip));
            return control;
        }
    }
}
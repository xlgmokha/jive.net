using System;
using System.Drawing;

namespace Gorilla.Commons.Windows.Forms.Resources
{
    public class HybridIcon : ApplicationIcon
    {
        readonly Image underlying_image;

        public HybridIcon(string name_of_the_icon, Action<ApplicationIcon> action) : base(name_of_the_icon, action)
        {
            if (icon_can_be_found())
            {
                underlying_image = Image.FromFile(find_full_path_to(this));
            }
        }

        public override void Dispose()
        {
            base.Dispose();
            if (underlying_image != null) underlying_image.Dispose();
        }

        static public implicit operator Image(HybridIcon icon_to_convert)
        {
            return icon_to_convert.underlying_image;
        }
    }
}
using System;
using System.Drawing;
using System.IO;
using Gorilla.Commons.Infrastructure.Reflection;

namespace Gorilla.Commons.Windows.Forms.Resources
{
    public class ApplicationIcon : IDisposable
    {
        readonly Icon underlying_icon;

        public ApplicationIcon(string name_of_the_icon, Action<ApplicationIcon> action)
        {
            this.name_of_the_icon = name_of_the_icon;
            if (icon_can_be_found())
            {
                action(this);
                underlying_icon = new Icon(find_full_path_to(this));
            }
        }

        public string name_of_the_icon { get; private set; }

        public virtual void Dispose()
        {
            if (underlying_icon != null) underlying_icon.Dispose();
        }

        static public implicit operator Icon(ApplicationIcon icon_to_convert)
        {
            return icon_to_convert.underlying_icon;
        }

        protected string find_full_path_to(ApplicationIcon icon_to_convert)
        {
            return Path.Combine(icon_to_convert.startup_directory() + @"\icons", icon_to_convert.name_of_the_icon);
        }

        protected bool icon_can_be_found()
        {
            return File.Exists(find_full_path_to(this));
        }
    }
}
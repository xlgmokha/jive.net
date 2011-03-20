using System.Collections.Specialized;

namespace gorilla.utility
{
    public class Settings
    {
        NameValueCollection settings;

        public Settings(NameValueCollection settings)
        {
            this.settings = settings;
        }

        public T named<T>(string key)
        {
            return settings[key].converted_to<T>();
        }
    }
}
using System.Windows.Forms;

namespace Gorilla.Commons.Windows.Forms.Keyboard
{
    public class ShortcutKey
    {
        private readonly Keys key;

        public ShortcutKey(Keys key)
        {
            this.key = key;
        }

        public ShortcutKey and(ShortcutKey other_key)
        {
            return new ShortcutKey(key | other_key.key);
        }

        public static implicit operator Keys(ShortcutKey key_to_convert)
        {
            return key_to_convert.key;
        }
    }
}
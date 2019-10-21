namespace jive
{
  static public class StringExtensions
  {
    static public string format(this string formatted_string, params object[] arguments)
    {
      return string.Format(formatted_string, arguments);
    }

    static public bool is_equal_to_ignoring_case(this string left, string right)
    {
      return string.Compare(left, right, true) == 0;
    }

    static public bool is_blank(this string message)
    {
      return string.IsNullOrEmpty(message);
    }

    static public string to_string<T>(this T item)
    {
      return "{0}".format(item);
    }
  }
}

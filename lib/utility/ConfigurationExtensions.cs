namespace jive.utility
{
  static public class ConfigurationExtensions
  {
    static public Configuration<T> then<T>(this Configuration<T> first, Configuration<T> second)
    {
      return new ChainedConfiguration<T>(first, second);
    }

    static public T and_configure_with<T>(this T item, Configuration<T> configuration)
    {
      configuration.configure(item);
      return item;
    }
  }
}

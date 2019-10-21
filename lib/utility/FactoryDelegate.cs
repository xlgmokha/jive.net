namespace jive.utility
{
  public delegate Out FactoryDelegate<in In, out Out>(In input);

  public delegate Out FactoryDelegate<out Out>();
}

namespace Gorilla.Commons.Utility.Core
{
    public delegate Out Factory<In, Out>(In input);

    public delegate Out Factory<Out>();
}
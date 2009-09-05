namespace Gorilla.Commons.Utility.Core
{
    public interface IIdentifiable<T>
    {
        Id<T> id { get; }
    }
}
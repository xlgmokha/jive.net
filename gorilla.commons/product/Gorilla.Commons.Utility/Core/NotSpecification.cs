namespace Gorilla.Commons.Utility.Core
{
    public class NotSpecification<T> : ISpecification<T>
    {
        readonly ISpecification<T> item_to_match;

        public NotSpecification(ISpecification<T> item_to_match)
        {
            this.item_to_match = item_to_match;
        }

        public bool is_satisfied_by(T item)
        {
            return !item_to_match.is_satisfied_by(item);
        }
    }
}
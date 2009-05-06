namespace Gorilla.Commons.Utility.Core
{
    public class AndSpecification<T> : ISpecification<T>
    {
        readonly ISpecification<T> left;
        readonly ISpecification<T> right;

        public AndSpecification(ISpecification<T> left, ISpecification<T> right)
        {
            this.left = left;
            this.right = right;
        }

        public bool is_satisfied_by(T item)
        {
            return left.is_satisfied_by(item) && right.is_satisfied_by(item);
        }
    }
}
namespace Gorilla.Commons.Utility.Core
{
    public class OrSpecification<T> : ISpecification<T>
    {
        readonly ISpecification<T> left;
        readonly ISpecification<T> right;

        public OrSpecification(ISpecification<T> left, ISpecification<T> right)
        {
            this.left = left;
            this.right = right;
        }

        public bool is_satisfied_by(T item)
        {
            return left.is_satisfied_by(item) || right.is_satisfied_by(item);
        }
    }
}
namespace Gorilla.Commons.Utility.Core
{
    public class FilteredVisitor<T> : IVisitor<T>
    {
        readonly ISpecification<T> condition;
        readonly IVisitor<T> visitor;

        public FilteredVisitor(ISpecification<T> condition, IVisitor<T> visitor)
        {
            this.condition = condition;
            this.visitor = visitor;
        }

        public void visit(T item_to_visit)
        {
            if (condition.is_satisfied_by(item_to_visit)) visitor.visit(item_to_visit);
        }
    }
}
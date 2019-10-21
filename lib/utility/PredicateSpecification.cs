using System;

namespace jive.utility
{
  public class PredicateSpecification<T> : Specification<T>
  {
    readonly Predicate<T> criteria;

    public PredicateSpecification(Predicate<T> criteria)
    {
      this.criteria = criteria;
    }

    public bool is_satisfied_by(T item)
    {
      return criteria(item);
    }
  }
}

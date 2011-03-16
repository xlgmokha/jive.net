using System;
using System.Collections.Generic;
using System.Linq;

namespace gorilla.utility
{
    static public class SpecificationExtensions
    {
        static public IEnumerable<T> that_satisfy<T>(this IEnumerable<T> items_to_peek_in_to,
                                                     Predicate<T> criteria_to_satisfy)
        {
            foreach (var item in items_to_peek_in_to ?? Enumerable.Empty<T>())
                if (item.satisfies(criteria_to_satisfy)) yield return item;
        }

        static public bool satisfies<T>(this T item_to_interrogate, Predicate<T> criteria_to_satisfy)
        {
            return criteria_to_satisfy(item_to_interrogate);
        }

        static public bool satisfies<T>(this T item_to_validate, Specification<T> criteria_to_satisfy)
        {
            return item_to_validate.satisfies(criteria_to_satisfy.is_satisfied_by);
        }

        static public Specification<T> and<T>(this Specification<T> left, Specification<T> right)
        {
            return new PredicateSpecification<T>(x => left.is_satisfied_by(x) && right.is_satisfied_by(x));
        }

        static public Specification<T> or<T>(this Specification<T> left, Specification<T> right)
        {
            return new PredicateSpecification<T>(x => left.is_satisfied_by(x) || right.is_satisfied_by(x));
        }

        static public Specification<T> not<T>(this Specification<T> original)
        {
            return new PredicateSpecification<T>(x => !original.is_satisfied_by(x));
        }
    }
}
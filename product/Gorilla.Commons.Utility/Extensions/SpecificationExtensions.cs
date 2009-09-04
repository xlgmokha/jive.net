using System;
using System.Collections.Generic;
using Gorilla.Commons.Utility.Core;

namespace Gorilla.Commons.Utility.Extensions
{
    public static class SpecificationExtensions
    {
        public static IEnumerable<T> that_satisfy<T>(this IEnumerable<T> items_to_peek_in_to,
                                                     Predicate<T> criteria_to_satisfy)
        {
            foreach (var item in items_to_peek_in_to ?? new List<T>())
                if (item.satisfies(criteria_to_satisfy)) yield return item;
        }

        public static bool satisfies<T>(this T item_to_interrogate, Predicate<T> criteria_to_satisfy)
        {
            return criteria_to_satisfy(item_to_interrogate);
        }

        public static bool satisfies<T>(this T item_to_validate, ISpecification<T> criteria_to_satisfy)
        {
            return item_to_validate.satisfies(criteria_to_satisfy.is_satisfied_by);
        }

        public static ISpecification<T> and<T>(this ISpecification<T> left, ISpecification<T> right)
        {
            return new PredicateSpecification<T>(x => left.is_satisfied_by(x) && right.is_satisfied_by(x));
        }

        public static ISpecification<T> or<T>(this ISpecification<T> left, ISpecification<T> right)
        {
            return new PredicateSpecification<T>(x => left.is_satisfied_by(x) || right.is_satisfied_by(x));
        }

        public static ISpecification<T> not<T>(this ISpecification<T> original)
        {
            return new PredicateSpecification<T>(x => !original.is_satisfied_by(x));
        }
    }
}
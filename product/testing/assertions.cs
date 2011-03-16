using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Machine.Specifications;

namespace Gorilla.Commons.Testing
{
    static public class Assertions
    {
        [AssertionMethod]
        static public void should_be_equal_to<T>(this T item_to_validate, T expected_value)
        {
            item_to_validate.ShouldEqual(expected_value);
        }

        [AssertionMethod]
        static public void should_be_the_same_instance_as<T>(this T left, T right)
        {
            ReferenceEquals(left, right).ShouldBeTrue();
        }

        [AssertionMethod]
        static public void should_be_null<T>(this T item)
        {
            item.ShouldBeNull();
        }

        [AssertionMethod]
        static public void should_not_be_null<T>(this T item) where T : class
        {
            item.ShouldNotBeNull();
        }

        [AssertionMethod]
        static public void should_be_greater_than<T>(this T actual, T expected) where T : IComparable
        {
            actual.ShouldBeGreaterThan(expected);
        }

        [AssertionMethod]
        static public void should_be_less_than(this int actual, int expected)
        {
            actual.ShouldBeLessThan(expected);
        }

        [AssertionMethod]
        static public void should_contain<T>(this IEnumerable<T> items_to_peek_in_to, T items_to_look_for)
        {
            items_to_peek_in_to.Contains(items_to_look_for).should_be_true();
        }

        [AssertionMethod]
        static public void should_not_contain<T>(this IEnumerable<T> items_to_peek_into, T item_to_look_for)
        {
            items_to_peek_into.Contains(item_to_look_for).should_be_false();
        }

        [AssertionMethod]
        static public void should_be_an_instance_of<T>(this object item)
        {
            item.should_be_an_instance_of(typeof (T));
        }

        [AssertionMethod]
        static public void should_be_an_instance_of(this object item, Type type)
        {
            item.ShouldBe(type);
        }

        [AssertionMethod]
        static public void should_have_thrown<TheException>(this Action action) where TheException : Exception
        {
            typeof (TheException).ShouldBeThrownBy(action);
        }

        [AssertionMethod]
        static public void should_be_true(this bool item)
        {
            item.ShouldBeTrue();
        }

        [AssertionMethod]
        static public void should_be_false(this bool item)
        {
            item.ShouldBeFalse();
        }

        [AssertionMethod]
        static public void should_contain<T>(this IEnumerable<T> items, params T[] items_to_find)
        {
            foreach (var item_to_find in items_to_find)
            {
                items.should_contain(item_to_find);
            }
        }

        [AssertionMethod]
        static public void should_only_contain<T>(this IEnumerable<T> items, params T[] itemsToFind)
        {
            items.Count().should_be_equal_to(itemsToFind.Length);
            items.should_contain(itemsToFind);
        }

        [AssertionMethod]
        static public void should_be_equal_ignoring_case(this string item, string other)
        {
            item.ShouldBeEqualIgnoringCase(other);
        }
    }
}
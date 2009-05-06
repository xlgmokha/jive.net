using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using MbUnit.Framework;

namespace Gorilla.Commons.Testing
{
    public static class Assertions
    {
        [AssertionMethod]
        public static void should_be_equal_to<T>(this T item_to_validate, T expected_value)
        {
            Assert.AreEqual(expected_value, item_to_validate);
        }

        [AssertionMethod]
        public static void should_be_the_same_instance_as<T>(this T left, T right)
        {
            Assert.IsTrue(ReferenceEquals(left, right));
        }

        [AssertionMethod]
        public static void should_be_null<T>(this T item)
        {
            Assert.IsNull(item);
        }

        [AssertionMethod]
        public static void should_not_be_null<T>(this T item) where T : class
        {
            Assert.IsNotNull(item);
        }

        [AssertionMethod]
        public static void should_be_greater_than<T>(this T actual, T expected) where T : IComparable
        {
            Assert.GreaterThan(actual, expected);
        }

        [AssertionMethod]
        public static void should_be_less_than(this int actual, int expected)
        {
            Assert.Less(actual, expected);
        }

        [AssertionMethod]
        public static void should_contain<T>(this IEnumerable<T> items_to_peek_in_to, T items_to_look_for)
        {
            items_to_peek_in_to.Contains(items_to_look_for).should_be_true();
        }

        [AssertionMethod]
        public static void should_not_contain<T>(this IEnumerable<T> items_to_peek_into, T item_to_look_for)
        {
            items_to_peek_into.Contains(item_to_look_for).should_be_false();
        }

        [AssertionMethod]
        public static void should_be_an_instance_of<T>(this object item)
        {
            item.should_be_an_instance_of(typeof (T));
        }

        [AssertionMethod]
        public static void should_be_an_instance_of(this object item, Type type)
        {
            Assert.IsInstanceOfType(type, item);
        }

        [AssertionMethod]
        public static void should_have_thrown<TheException>(this Action action) where TheException : Exception
        {
            try
            {
                action();
                Assert.Fail("the_exception_was_not_thrown");
            }
            catch (Exception e)
            {
                should_be_an_instance_of<TheException>(e);
            }
        }

        [AssertionMethod]
        public static void should_be_true(this bool item)
        {
            Assert.IsTrue(item);
        }

        [AssertionMethod]
        public static void should_be_false(this bool item)
        {
            Assert.IsFalse(item);
        }

        [AssertionMethod]
        public static void should_contain<T>(this IEnumerable<T> items, params T[] items_to_find)
        {
            foreach (var item_to_find in items_to_find)
            {
                items.should_contain(item_to_find);
            }
        }

        [AssertionMethod]
        public static void should_only_contain<T>(this IEnumerable<T> items, params T[] itemsToFind)
        {
            items.Count().should_be_equal_to(itemsToFind.Length);
            items.should_contain(itemsToFind);
        }

        [AssertionMethod]
        public static void should_be_equal_ignoring_case(this string item, string other)
        {
            StringAssert.AreEqualIgnoreCase(item, other);
        }
    }
}
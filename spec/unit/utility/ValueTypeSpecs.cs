using System;
using jive.utility;
using Machine.Specifications;

namespace specs.unit.utility
{
  public class ValueTypeSpecs
  {
    public class when_two_different_instances_of_the_same_type_have_the_same_values
    {
      It should_consider_them_equal = () =>
      {
        var birthDate = DateTime.Today;
        new TestType {first = "mo", BirthDate = birthDate}
        .ShouldEqual(new TestType {first = "mo", BirthDate = birthDate});
      };
    }

    public class when_comparing_a_single_instance
    {
      It should_consider_them_equal = () =>
      {
        var instance = new TestType {first = "mo", BirthDate = DateTime.Today};
        instance.ShouldEqual(instance);
      };
    }

    public class when_two_different_instances_of_the_same_type_have_different_values
    {
      It should_consider_them_equal = () =>
      {
        new TestType {first = "mo", BirthDate = DateTime.Today}
        .ShouldNotEqual(new TestType {first = "mo", BirthDate = DateTime.Today.AddDays(-1)});
      };
    }

    class TestType : ValueType<TestType>
    {
      public string first { get; set; }
      public DateTime BirthDate { get; set; }
    }
  }
}

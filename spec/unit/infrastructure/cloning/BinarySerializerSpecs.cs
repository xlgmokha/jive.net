using System;
using System.IO;
using jive.infrastructure.cloning;
using Machine.Specifications;

namespace specs.unit.infrastructure.cloning
{
  [Subject(typeof (BinarySerializer<TestItem>))]
  public abstract class when_a_file_is_specified_to_serialize_an_item_to
  {
    static Serializer<TestItem> create_sut()
    {
      return new BinarySerializer<TestItem>(file_name);
    }

    Establish c = () =>
    {
      file_name = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "serialized.dat");

      sut = create_sut();
    };

    Cleanup aeo = () =>
    {
      if (File.Exists(file_name)) File.Delete(file_name);
    };

    static protected string file_name;
    static protected Serializer<TestItem> sut;
  }

  [Subject(typeof (BinarySerializer<TestItem>))]
  public class when_serializing_an_item : when_a_file_is_specified_to_serialize_an_item_to
  {
    It should_serialize_the_item_to_a_file = () => File.Exists(file_name).should_be_true();

    Because b = () => sut.serialize(new TestItem(string.Empty));
  }

  [Subject(typeof (BinarySerializer<TestItem>))]
  public class when_deserializing_an_item : when_a_file_is_specified_to_serialize_an_item_to
  {
    It should_be_able_to_deserialize_from_a_serialized_file = () => result.should_be_equal_to(original);

    Establish c = () =>
    {
      original = new TestItem("hello world");
    };

    Because b = () =>
    {
      sut.serialize(original);
      result = sut.deserialize();
    };

    static TestItem original;
    static TestItem result;
  }

  [Serializable]
  public class TestItem : IEquatable<TestItem>
  {
    public TestItem(string text)
    {
      Text = text;
    }

    public string Text { get; set; }

    public bool Equals(TestItem testItem)
    {
      return testItem != null;
    }

    public override bool Equals(object obj)
    {
      return ReferenceEquals(this, obj) || Equals(obj as TestItem);
    }

    public override int GetHashCode()
    {
      return 0;
    }
  }
}

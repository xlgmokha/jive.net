using System;
using System.IO;
using developwithpassion.bdd.contexts;
using Gorilla.Commons.Testing;
using MbUnit.Framework;

namespace Gorilla.Commons.Infrastructure.Cloning
{
    [Concern(typeof (BinarySerializer<TestItem>))]
    public abstract class when_a_file_is_specified_to_serialize_an_item_to : concerns_for<Serializer<TestItem>, BinarySerializer<TestItem>>
    {
        public override Serializer<TestItem> create_sut()
        {
            return new BinarySerializer<TestItem>(file_name);
        }

        context c = () => { file_name = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "serialized.dat"); };

        after_each_observation aeo = () => { if (File.Exists(file_name)) File.Delete(file_name); };

        static protected string file_name;
    }

    [Concern(typeof (BinarySerializer<TestItem>))]
    public class when_serializing_an_item : when_a_file_is_specified_to_serialize_an_item_to
    {
        it should_serialize_the_item_to_a_file = () => FileAssert.Exists(file_name);

        because b = () => sut.serialize(new TestItem(string.Empty));
    }

    [Concern(typeof (BinarySerializer<TestItem>))]
    public class when_deserializing_an_item : when_a_file_is_specified_to_serialize_an_item_to
    {
        it should_be_able_to_deserialize_from_a_serialized_file = () => result.should_be_equal_to(original);

        context c = () => { original = new TestItem("hello world"); };

        because b = () =>
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
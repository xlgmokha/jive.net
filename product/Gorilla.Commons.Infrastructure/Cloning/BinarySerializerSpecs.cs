using System;
using System.IO;
using developwithpassion.bdd.contexts;
using Gorilla.Commons.Testing;
using MbUnit.Framework;

namespace Gorilla.Commons.Infrastructure.Cloning
{
    [Concern(typeof(BinarySerializer<TestItem>))]
    public abstract class behaves_like_serializer : concerns_for<ISerializer<TestItem>>
    {
        public override ISerializer<TestItem> create_sut()
        {
            return new BinarySerializer<TestItem>(file_name);
        }

        context c = () => { file_name = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Serialized.dat"); };

        after_each_observation aeo = () => { if (File.Exists(file_name)) File.Delete(file_name); };

        protected static string file_name;
    }

    public class when_serializing_an_item : behaves_like_serializer
    {
        it should_serialize_the_item_to_a_file = () => FileAssert.Exists(file_name);

        because b = () => sut.serialize(new TestItem(string.Empty));
    }

    public class when_deserializing_an_item : behaves_like_serializer
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
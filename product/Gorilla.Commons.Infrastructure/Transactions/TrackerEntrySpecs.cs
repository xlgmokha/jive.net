using System;
using developwithpassion.bdd.contexts;
using Gorilla.Commons.Testing;
using Gorilla.Commons.Utility.Core;
using Gorilla.Commons.Utility.Extensions;

namespace Gorilla.Commons.Infrastructure.Transactions
{
    public class TrackerEntrySpecs
    {
    }

    public abstract class behaves_like_tracker_entry : concerns_for<ITrackerEntry<Pillow>>
    {
    }

    [Concern(typeof (ITrackerEntry<>))]
    public class when_comparing_the_current_instance_of_a_component_with_its_original_and_it_has_changes :
        behaves_like_tracker_entry
    {
        it should_indicate_that_there_are_changes = () => result.should_be_true();

        because b = () => { result = sut.has_changes(); };

        public override ITrackerEntry<Pillow> create_sut()
        {
            return new TrackerEntry<Pillow>(new Pillow("pink"), new Pillow("yellow"));
        }

        static bool result;
    }

    [Concern(typeof (ITrackerEntry<>))]
    public class when_the_original_instance_has_a_null_field_that_is_now_not_null :
        behaves_like_tracker_entry
    {
        it should_indicate_that_there_are_changes = () => result.should_be_true();

        because b = () => { result = sut.has_changes(); };

        public override ITrackerEntry<Pillow> create_sut()
        {
            return new TrackerEntry<Pillow>(new Pillow(null), new Pillow("yellow"));
        }

        static bool result;
    }

    [Concern(typeof (ITrackerEntry<>))]
    public class when_the_original_instance_had_a_non_null_field_and_the_current_instance_has_a_null_field :
        behaves_like_tracker_entry
    {
        it should_indicate_that_there_are_changes = () => result.should_be_true();

        because b = () => { result = sut.has_changes(); };

        context c = () =>
                        {
                            var id = Guid.NewGuid();
                            original = new Pillow("green", id);
                            current = new Pillow(null, id);
                        };

        public override ITrackerEntry<Pillow> create_sut()
        {
            return new TrackerEntry<Pillow>(original, current);
        }

        static bool result;
        static Pillow original;
        static Pillow current;
    }

    [Concern(typeof (ITrackerEntry<>))]
    public class when_the_original_instance_has_the_same_value_as_the_current_instance :
        behaves_like_tracker_entry
    {
        it should_indicate_that_there_are_no_changes = () => result.should_be_false();

        because b = () => { result = sut.has_changes(); };

        context c = () =>
                        {
                            var id = Guid.NewGuid();
                            original = new Pillow("green", id);
                            current = new Pillow("green", id);
                        };

        public override ITrackerEntry<Pillow> create_sut()
        {
            return new TrackerEntry<Pillow>(original, current);
        }

        static bool result;
        static Pillow original;
        static Pillow current;
    }

    public class Pillow : IIdentifiable<Guid>
    {
        readonly string color;

        public Pillow(string color) : this(color, Guid.NewGuid())
        {
        }

        public Pillow(string color, Guid id)
        {
            this.color = color;
            this.id = id;
        }

        public Guid id { get; set; }

        public bool Equals(Pillow other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return other.id.Equals(id);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (Pillow)) return false;
            return Equals((Pillow) obj);
        }

        public override int GetHashCode()
        {
            return id.GetHashCode();
        }

        public override string ToString()
        {
            return "{0} id: {1}".formatted_using(base.ToString(), id);
        }
    }
}
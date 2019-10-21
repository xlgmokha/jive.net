using System;

namespace jive
{
  [Serializable]
  public class Id<T>
  {
    static public readonly Id<T> Default = new Id<T>(default(T));
    readonly T id;

    public Id(T id)
    {
      this.id = id;
    }

    static public implicit operator Id<T>(T id)
    {
      return new Id<T>(id);
    }

    static public implicit operator T(Id<T> id)
    {
      return id.id;
    }

    public bool Equals(Id<T> other)
    {
      if (ReferenceEquals(null, other)) return false;
      if (ReferenceEquals(this, other)) return true;
      return Equals(other.id, id);
    }

    public override bool Equals(object obj)
    {
      if (ReferenceEquals(null, obj)) return false;
      if (ReferenceEquals(this, obj)) return true;
      if (obj.GetType() != typeof (Id<T>)) return false;
      return Equals((Id<T>) obj);
    }

    public override int GetHashCode()
    {
      return id.GetHashCode();
    }
  }
}

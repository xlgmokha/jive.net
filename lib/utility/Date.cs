using System;
using System.Globalization;

namespace jive.utility
{
  [Serializable]
  public class Date :  IComparable<Date>, IComparable, IEquatable<Date>
  {
    readonly long ticks;

    public Date(int year, int month, int day)
    {
      ticks = new DateTime(year, month, day).Ticks;
    }

    public bool is_in(Year the_year)
    {
      return the_year.represents(to_date_time());
    }

    public DateTime to_date_time()
    {
      return new DateTime(ticks);
    }

    static public implicit operator Date(DateTime date)
    {
      return new Date(date.Year, date.Month, date.Day);
    }

    static public implicit operator DateTime(Date date)
    {
      return date.to_date_time();
    }

    public int CompareTo(Date other)
    {
      var the_other_date = other.downcast_to<Date>();
      if (ticks.Equals(the_other_date.ticks))
      {
        return 0;
      }
      return ticks > the_other_date.ticks ? 1 : -1;
    }

    public bool Equals(Date other)
    {
      if (ReferenceEquals(null, other)) return false;
      if (ReferenceEquals(this, other)) return true;
      return other.ticks == ticks;
    }

    public override bool Equals(object obj)
    {
      if (ReferenceEquals(null, obj)) return false;
      if (ReferenceEquals(this, obj)) return true;
      if (obj.GetType() != typeof (Date)) return false;
      return Equals((Date) obj);
    }

    public override int GetHashCode()
    {
      return ticks.GetHashCode();
    }

    public static bool operator ==(Date left, Date right)
    {
      return Equals(left, right);
    }

    public static bool operator !=(Date left, Date right)
    {
      return !Equals(left, right);
    }

    public override string ToString()
    {
      return new DateTime(ticks, DateTimeKind.Local).ToString("MMM dd yyyy", CultureInfo.InvariantCulture);
    }

    int IComparable.CompareTo(object obj)
    {
      if (obj.is_an_implementation_of<Date>())
        return CompareTo(obj.downcast_to<Date>());
      throw new InvalidOperationException();
    }
  }
}

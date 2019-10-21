using System;

namespace jive
{
  public class Year
  {
    readonly int the_underlying_year;

    public Year(int year) : this(new DateTime(year, 01, 01))
    {
    }

    public Year(DateTime date)
    {
      the_underlying_year = date.Year;
    }

    static public implicit operator Year(int year)
    {
      return new Year(year);
    }

    public bool Equals(Year obj)
    {
      if (ReferenceEquals(null, obj)) return false;
      if (ReferenceEquals(this, obj)) return true;
      return obj.the_underlying_year == the_underlying_year;
    }

    public override bool Equals(object obj)
    {
      if (ReferenceEquals(null, obj)) return false;
      if (ReferenceEquals(this, obj)) return true;
      if (obj.GetType() != typeof (Year)) return false;
      return Equals((Year) obj);
    }

    public override int GetHashCode()
    {
      return the_underlying_year;
    }

    public bool represents(DateTime time)
    {
      return time.Year.Equals(the_underlying_year);
    }

    public override string ToString()
    {
      return the_underlying_year.ToString();
    }
  }
}

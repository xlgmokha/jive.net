using System;
using System.Globalization;

namespace jive
{
  public class Percent
  {
    readonly decimal percentage;

    public Percent(decimal percentage)
    {
      this.percentage = percentage;
    }

    public Percent(decimal portion_of_total, decimal total)
    {
      percentage = portion_of_total/total;
      percentage *= 100;
      percentage = Math.Round(percentage, 1);
    }

    public bool represents(Percent other_percent)
    {
      return Equals(other_percent);
    }

    public bool is_less_than(Percent other_percent)
    {
      return percentage.CompareTo(other_percent.percentage) < 0;
    }

    public static implicit operator Percent(decimal percentage)
    {
      return new Percent(percentage);
    }

    public bool Equals(Percent other)
    {
      if (ReferenceEquals(null, other)) return false;
      if (ReferenceEquals(this, other)) return true;
      return other.percentage == percentage;
    }

    public override bool Equals(object obj)
    {
      if (ReferenceEquals(null, obj)) return false;
      if (ReferenceEquals(this, obj)) return true;
      if (obj.GetType() != typeof (Percent)) return false;
      return Equals((Percent) obj);
    }

    public override int GetHashCode()
    {
      return percentage.GetHashCode();
    }

    public override string ToString()
    {
      return percentage.ToString(CultureInfo.InvariantCulture);
    }
  }
}

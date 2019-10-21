using jive;
using Machine.Specifications;

namespace specs.unit.utility
{
  [Subject(typeof (Percent))]
  public class when_comparing_fifty_divided_by_one_hundred_to_fifty_percent
  {
    It they_should_be_equal = () => new Percent(50, 100).should_be_equal_to<Percent>(50);
  }

  [Subject(typeof (Percent))]
  public class when_calculating_a_fractional_percentage
  {
    It should_return_the_correct_percentage = () => new Percent(30, 90).should_be_equal_to<Percent>(33.3m);
  }

  [Subject(typeof (Percent))]
  public class when_checking_if_50_percent_is_less_than_51_percent 
  {
    It should_return_true = () => new Percent(50).is_less_than(new Percent(51)).should_be_true();
  }

  [Subject(typeof (Percent))]
  public class when_checking_if_51_percent_is_less_than_50_percent 
  {
    It should_return_false = () => new Percent(51).is_less_than(new Percent(50)).should_be_false();
  }

  [Subject(typeof (Percent))]
  public class when_checking_if_50_percent_is_less_than_50_percent 
  {
    It should_return_false = () => new Percent(50).is_less_than(new Percent(50)).should_be_false();
  }
}

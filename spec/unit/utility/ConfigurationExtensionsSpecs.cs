using jive;
using Machine.Specifications;

namespace specs.unit.utility
{
  public class ConfigurationExtensionsSpecs
  {
    public interface IDbCommand {
      void Execute();
    }

    public class when_configuring_an_item
    {
      It should_return_the_item_that_was_configured_when_completed = () => result.should_be_equal_to(item.Object);

      Establish context = () =>
      {
        configuration = Create.an<Configuration<IDbCommand>>();
        item = Create.an<IDbCommand>();
      };

      Because of = () =>
      {
        result = item.Object.and_configure_with(configuration.Object);
      };

      static Moq.Mock<Configuration<IDbCommand>> configuration;
      static Moq.Mock<IDbCommand> item;
      static IDbCommand result;
    }
  }
}

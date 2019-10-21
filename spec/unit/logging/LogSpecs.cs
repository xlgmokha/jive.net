using jive.container;
using jive.logging;
using Machine.Specifications;

namespace specs.unit.logging
{
  [Subject(typeof (Log))]
  public class when_creating_a_logger_for_a_particular_type
  {
    It should_return_the_logger_created_for_that_type = () => result.should_be_equal_to(logger.Object);

    Establish c =
      () =>
      {
        var factory = Create.an<LogFactory>();
        var registry = Create.an<DependencyRegistry>();
        logger = Create.an<Logger>();
        registry.Setup(x => x.get_a<LogFactory>()).Returns(factory.Object);
        factory.Setup(x => x.create_for(typeof (string))).Returns(logger.Object);

        Resolve.initialize_with(registry.Object);
      };

    Because b = () =>
    {
      result = Log.For("mo");
    };

    Cleanup a = () => Resolve.initialize_with(null);

    static Logger result;
    static Moq.Mock<Logger> logger;
  }
}

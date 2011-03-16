using gorilla.infrastructure.container;
using gorilla.infrastructure.logging;
using Machine.Specifications;

namespace specs.unit.infrastructure.logging
{
    [Subject(typeof (Log))]
    public class when_creating_a_logger_for_a_particular_type
    {
        It should_return_the_logger_created_for_that_type = () => result.should_be_equal_to(logger);

        Establish c =
            () =>
            {
                var factory = Create.an<LogFactory>();
                var registry = Create.an<DependencyRegistry>();
                logger = Create.an<Logger>();
                registry.is_told_to(x => x.get_a<LogFactory>()).it_will_return(factory);
                factory.is_told_to(x => x.create_for(typeof (string))).it_will_return(logger);

                Resolve.initialize_with(registry);
            };

        Because b = () =>
        {
            result = Log.For("mo");
        };

        Cleanup a = () => Resolve.initialize_with(null);

        static Logger result;
        static Logger logger;
    }
}
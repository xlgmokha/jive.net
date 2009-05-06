using developwithpassion.bdd.contexts;
using Gorilla.Commons.Infrastructure.Container;
using Gorilla.Commons.Testing;

namespace Gorilla.Commons.Infrastructure.Logging
{
    [Concern(typeof (Log))]
    public class when_creating_a_logger_for_a_particular_type_ : concerns
    {
        it should_return_the_logger_created_for_that_type = () => result.should_be_equal_to(logger);

        context c =
            () =>
                {
                    var factory = an<ILogFactory>();
                    var registry = an<IDependencyRegistry>();
                    logger = an<ILogger>();
                    registry.is_told_to(x => x.get_a<ILogFactory>()).it_will_return(factory);
                    factory.is_told_to(x => x.create_for(typeof (string))).it_will_return(logger);

                    Resolve.initialize_with(registry);
                };

        because b = () => { result = Log.For("mo"); };

        after_each_observation a = () => Resolve.initialize_with(null);

        static ILogger result;
        static ILogger logger;
    }
}
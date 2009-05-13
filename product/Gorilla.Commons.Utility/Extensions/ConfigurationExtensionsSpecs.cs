using System.Data;
using developwithpassion.bdd.contexts;
using Gorilla.Commons.Testing;
using Gorilla.Commons.Utility.Core;

namespace Gorilla.Commons.Utility.Extensions
{
    public class ConfigurationExtensionsSpecs
    {
    }

    public class when_configuring_an_item : concerns
    {
        it should_return_the_item_that_was_configured_when_completed = () => result.should_be_equal_to(item);

        context c = () =>
                        {
                            configuration = an<IConfiguration<IDbCommand>>();
                            item = an<IDbCommand>();
                        };

        because b = () => { result = item.and_configure_with(configuration); };

        static IConfiguration<IDbCommand> configuration;
        static IDbCommand item;
        static IDbCommand result;
    }
}
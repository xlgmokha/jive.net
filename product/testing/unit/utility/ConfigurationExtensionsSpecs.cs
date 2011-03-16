using System.Data;
using gorilla.utility;
using Machine.Specifications;

namespace specs.unit.utility
{
    public class ConfigurationExtensionsSpecs
    {
        public class when_configuring_an_item
        {
            It should_return_the_item_that_was_configured_when_completed = () => result.should_be_equal_to(item);

            Establish context = () =>
            {
                configuration = Create.an<Configuration<IDbCommand>>();
                item = Create.an<IDbCommand>();
            };

            Because of = () =>
            {
                result = item.and_configure_with(configuration);
            };

            static Configuration<IDbCommand> configuration;
            static IDbCommand item;
            static IDbCommand result;
        }
    }
}
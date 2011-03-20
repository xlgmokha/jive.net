using System.Collections.Specialized;
using gorilla.utility;
using Machine.Specifications;

namespace specs.unit.utility
{
    public class SettingsSpecs
    {
        public abstract class concern
        {
            Establish context = () =>
            {
                settings = new NameValueCollection();
                sut = new Settings(settings);
            };

            static protected Settings sut;
            static protected NameValueCollection settings;
        }

        public class when_pulling_out_a_setting : concern
        {
            It should_return_the_correct_value = () => result.should_be_equal_to("blah");

            Establish context = () => { settings["the.key"] = "blah"; };

            Because of = () => { result = sut.named<string>("the.key"); };

            static string result;
        }
    }
}
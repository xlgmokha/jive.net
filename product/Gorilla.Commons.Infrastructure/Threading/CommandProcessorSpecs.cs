using developwithpassion.bdd.contexts;
using Gorilla.Commons.Testing;
using Gorilla.Commons.Utility.Core;

namespace Gorilla.Commons.Infrastructure.Threading
{
    [Concern(typeof (CommandProcessor))]
    public abstract class behaves_like_a_command_processor : concerns_for<ICommandProcessor, CommandProcessor>
    {
    }

    public class when_running_all_the_queued_commands_waiting_for_execution : behaves_like_a_command_processor
    {
        it should_run_the_first_command_in_the_queue = () => first_command.was_told_to(f => f.run());

        it should_run_the_second_command_in_the_queue = () => second_command.was_told_to(f => f.run());

        context c = () =>
                        {
                            first_command = an<ICommand>();
                            second_command = an<ICommand>();
                        };

        because b = () =>
                        {
                            sut.add(first_command);
                            sut.add(second_command);
                            sut.run();
                        };

        static ICommand first_command;
        static ICommand second_command;
    }

    public class when_attempting_to_rerun_the_command_processor : behaves_like_a_command_processor
    {
        it should_not_re_run_the_commands_that_have_already_executed =
            () => first_command.was_told_to(f => f.run()).only_once();

        context c = () => { first_command = an<ICommand>(); };

        because b = () =>
                        {
                            sut.add(first_command);
                            sut.run();
                            sut.run();
                        };

        static ICommand first_command;
    }
}
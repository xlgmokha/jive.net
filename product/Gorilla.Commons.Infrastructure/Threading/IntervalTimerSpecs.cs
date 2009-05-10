using System;
using System.Timers;
using developwithpassion.bdd.contexts;
using Gorilla.Commons.Testing;
using Rhino.Mocks;

namespace Gorilla.Commons.Infrastructure.Threading
{
    [Concern(typeof (IntervalTimer))]
    public abstract class behaves_like_an_interval_timer : concerns_for<ITimer, IntervalTimer>
    {
        context c = () => { factory = the_dependency<ITimerFactory>(); };

        protected static ITimerFactory factory;
    }

    [Concern(typeof (IntervalTimer))]
    public class when_starting_a_timer_for_a_new_client : behaves_like_an_interval_timer
    {
        static ITimerClient client;
        static Timer timer;

        it should_create_a_new_timer = () => factory.was_told_to(f => f.create_for(new TimeSpan(0, 10, 0)));

        it should_start_the_timer = () => timer.was_told_to(t => t.Start());

        context c = () =>
                        {
                            client = an<ITimerClient>();
                            timer = dependency<Timer>();

                            factory.is_told_to(f => f.create_for(new TimeSpan(0, 10, 0))).it_will_return(timer);
                        };

        because b = () => sut.start_notifying(client, new TimeSpan(0, 10, 0));
    }

    [Concern(typeof (IntervalTimer))]
    public class when_starting_a_timer_for_an_existing_client : behaves_like_an_interval_timer
    {
        it should_stop_the_previously_started_timer = () =>
                                                          {
                                                              first_timer.was_told_to(t => t.Stop());
                                                              first_timer.was_told_to(t => t.Dispose());
                                                          };

        it should_start_a_new_timer = () => second_timer.was_told_to(t => t.Start());

        context c = () =>
                        {
                            client = an<ITimerClient>();
                            first_timer = dependency<Timer>();
                            second_timer = dependency<Timer>();

                            factory.is_told_to(f => f.create_for(new TimeSpan(0, 1, 1))).it_will_return(first_timer);
                            factory.is_told_to(f => f.create_for(new TimeSpan(0, 2, 2))).it_will_return(second_timer);
                        };

        because b = () =>
                        {
                            sut.start_notifying(client, new TimeSpan(0, 1, 1));
                            sut.start_notifying(client, new TimeSpan(0, 2, 2));
                        };

        static ITimerClient client;
        static Timer first_timer;
        static Timer second_timer;
    }

    [Concern(typeof (IntervalTimer))]
    public class when_a_timer_elapses : behaves_like_an_interval_timer
    {
        it should_notify_the_timer_client = () => client.was_told_to(c => c.notify());

        static ITimerClient client;
        static Timer timer;

        context c = () =>
                        {
                            client = an<ITimerClient>();
                            timer = dependency<Timer>();
                            factory.is_told_to(f => f.create_for(Arg<TimeSpan>.Is.Anything)).it_will_return(timer);
                        };

        because b = () =>
                        {
                            sut.start_notifying(client, new TimeSpan(0, 10, 0));
                            timer.Raise(t => t.Elapsed += null, timer, null);
                        };
    }

    [Concern(typeof (IntervalTimer))]
    public class when_stopping_notifications_for_an_existing_timer_client : behaves_like_an_interval_timer
    {
        static ITimerClient client;
        static Timer timer;

        it should_stop_the_timer_that_was_started_for_the_client = () => timer.was_told_to(t => t.Stop());

        it should_dispose_the_timer_that_was_started_for_the_client = () => timer.was_told_to(t => t.Dispose());

        context c = () =>
                        {
                            client = an<ITimerClient>();
                            timer = dependency<Timer>();

                            when_the(factory).is_told_to(t => t.create_for(Arg<TimeSpan>.Is.Anything)).it_will_return(
                                timer);
                        };

        because b = () =>
                        {
                            sut.start_notifying(client, new TimeSpan(0, 0, 1));
                            sut.stop_notifying(client);
                        };
    }

    [Concern(typeof (IntervalTimer))]
    public class when_attempting_to_stop_notification_for_a_client_that_doesnt_have_a_timer_started_for_it :
        behaves_like_an_interval_timer
    {
        it should_not_blow_up = () => { };

        context c = () => { client = an<ITimerClient>(); };

        because b = () => sut.stop_notifying(client);

        static ITimerClient client;
    }
}
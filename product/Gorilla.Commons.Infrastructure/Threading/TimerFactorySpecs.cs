using System;
using System.Timers;
using developwithpassion.bdd.contexts;
using Gorilla.Commons.Testing;

namespace Gorilla.Commons.Infrastructure.Threading
{
    [Concern(typeof (TimerFactory))]
    public abstract class behaves_like_a_timer_factory : concerns_for<ITimerFactory, TimerFactory>
    {
        public override ITimerFactory create_sut()
        {
            return new TimerFactory();
        }
    }

    [Concern(typeof (TimerFactory))]
    public class when_creating_a_timer : behaves_like_a_timer_factory
    {
        it should_return_a_timer_with_the_correct_interval = () => result.Interval.should_be_equal_to(1000);

        because b = () => { result = sut.create_for(new TimeSpan(0, 0, 1)); };

        static Timer result;
    }

    [Concern(typeof (TimerFactory))]
    public class when_creating_a_timer_with_an_interval_in_milliseconds : behaves_like_a_timer_factory
    {
        it should_return_a_timer_with_the_correct_polling_interval =
            () => result.Interval.should_be_equal_to(milliseconds);

        because b = () =>
                        {
                            var timer_interval = new TimeSpan(50);
                            milliseconds = 50;
                            result = sut.create_for(timer_interval);
                        };

        static Timer result;
        static double milliseconds;
    }
}
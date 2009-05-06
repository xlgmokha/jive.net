using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using Gorilla.Commons.Utility.Extensions;

namespace Gorilla.Commons.Infrastructure.Eventing
{
    public interface IEventAggregator
    {
        void subscribe_to<Event>(IEventSubscriber<Event> subscriber) where Event : IEvent;
        void subscribe<Listener>(Listener subscriber) where Listener : class;
        void publish<Event>(Event the_event_to_broadcast) where Event : IEvent;
        void publish<T>(Expression<Action<T>> call) where T : class;
        void publish<Event>() where Event : IEvent, new();
    }

    public class EventAggregator : IEventAggregator
    {
        readonly SynchronizationContext context;
        readonly HashSet<object> subscribers;
        readonly object mutex;

        public EventAggregator(SynchronizationContext context)
        {
            subscribers = new HashSet<object>();
            mutex = new object();
            this.context = context;
        }

        public void subscribe_to<Event>(IEventSubscriber<Event> subscriber) where Event : IEvent
        {
            subscribe(subscriber);
        }

        public void subscribe<Listener>(Listener subscriber) where Listener : class
        {
            within_lock(() => subscribers.Add(subscriber));
        }

        public void publish<Event>(Event the_event_to_broadcast) where Event : IEvent
        {
            process(() => subscribers.call_on_each<IEventSubscriber<Event>>(x => x.notify(the_event_to_broadcast)));
        }

        public void publish<T>(Expression<Action<T>> call) where T : class
        {
            process(() => subscribers.each(x => x.call_on(call.Compile())));
        }

        public void publish<Event>() where Event : IEvent, new()
        {
            publish(new Event());
        }

        void within_lock(Action action)
        {
            lock (mutex) action();
        }

        void process(Action action)
        {
            context.Send(x => action(), new object());
        }
    }
}
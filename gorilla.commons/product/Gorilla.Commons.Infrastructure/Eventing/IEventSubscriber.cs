namespace Gorilla.Commons.Infrastructure.Eventing
{
    public interface IEventSubscriber<Event> where Event : IEvent
    {
        void notify(Event message);
    }
}
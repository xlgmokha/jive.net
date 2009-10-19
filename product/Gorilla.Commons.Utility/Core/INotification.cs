namespace Gorilla.Commons.Utility.Core
{
    public interface INotification
    {
        void notify(params NotificationMessage[] messages);
    }
}
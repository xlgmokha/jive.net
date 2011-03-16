namespace gorilla.utility
{
    public interface Notification
    {
        void notify(params NotificationMessage[] messages);
    }
}
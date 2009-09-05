namespace Gorilla.Commons.Utility.Core
{
    public class NotificationMessage
    {
        public string message { get; set; }

        static public implicit operator string(NotificationMessage message)
        {
            return message.ToString();
        }

        static public implicit operator NotificationMessage(string message)
        {
            return new NotificationMessage {message = message};
        }

        public override string ToString()
        {
            return message;
        }

        public bool Equals(NotificationMessage obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj.message, message);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (NotificationMessage)) return false;
            return Equals((NotificationMessage) obj);
        }

        public override int GetHashCode()
        {
            return (message != null ? message.GetHashCode() : 0);
        }
    }
}
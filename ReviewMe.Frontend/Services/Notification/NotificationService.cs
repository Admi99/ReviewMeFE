namespace ReviewMe.Frontend.Services.Notification
{
    public class NotificationService : INotificationService
    {
        private const int DefaultTimeout = 5000; // milliseconds

        public void DisplayNotification(string message)
            => DisplayNotification(message, NotificationType.Info, string.Empty, DefaultTimeout);

        public void DisplayNotification(string message, NotificationType type)
            => DisplayNotification(message, type, string.Empty, DefaultTimeout);

        public void DisplayNotification(string message, NotificationType type, string title, int timeout)
        {
            if (Handlers.NotificationHandler != null)
                Handlers.NotificationHandler(message, type.ToString().ToLowerInvariant(), title, timeout);
        }
    }
}
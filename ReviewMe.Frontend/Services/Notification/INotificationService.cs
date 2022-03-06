namespace ReviewMe.Frontend.Services.Notification
{
    public interface INotificationService
    {
        public void DisplayNotification(string message);

        public void DisplayNotification(string message, NotificationType type);

        public void DisplayNotification(string message, NotificationType type, string title, int timeout);
    }
}
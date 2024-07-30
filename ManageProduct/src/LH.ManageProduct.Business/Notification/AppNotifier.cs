using LH.ManageProduct.Business.Interfaces;

namespace LH.ManageProduct.Business.Notification
{
    public class AppNotifier : INotification
    {
        private List<AppNotification> _notifications;
        public AppNotifier()
        {
            _notifications = new List<AppNotification>();
        }

        public void Handle(AppNotification notification)
        {
            _notifications.Add(notification);
        }

        public List<AppNotification> GetNotifications()
        {
            return _notifications;
        }

        public bool HasNotification()
        {
            return _notifications.Any();
        }
    }
}

using LH.ManageProduct.Business.Notification;

namespace LH.ManageProduct.Business.Interfaces
{
    public interface INotification
    {
        bool HasNotification();
        List<AppNotification> GetNotifications();
        void Handle(AppNotification notification);
    }
}

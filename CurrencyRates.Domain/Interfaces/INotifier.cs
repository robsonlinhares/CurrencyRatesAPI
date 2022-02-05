using CurrencyRates.Domain.Notifications;

namespace CurrencyRates.Domain.Interfaces
{
    public interface INotifier
    {
        bool HasNotification();
        List<Notification> GetNotifications();
        void Handle(Notification notificacao);
    }
}

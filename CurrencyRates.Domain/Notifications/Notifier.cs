using CurrencyRates.Domain.Interfaces;

namespace CurrencyRates.Domain.Notifications
{
    public class Notifier : INotifier
    {
        private List<Notification> _notifications;

        public Notifier()
        {
            _notifications = new List<Notification>();
        }

        public List<Notification> GetNotifications()
        {
            return _notifications;
        }

        public void Handle(Notification notification)
        {
            _notifications.Add(notification);
        }

        public bool HasNotification()
        {
            return _notifications.Any();
        }

        public void Notify(string message)
        {    
            Handle(new Notification(message));
        }
    }
}

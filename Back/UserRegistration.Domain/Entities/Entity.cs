using Flunt.Notifications;

namespace UserRegistration.Domain.Entities
{
    public abstract class Entity : Notifiable<Notification>
    {
        public int Id { get; private set; }
    }
}

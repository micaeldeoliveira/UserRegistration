using Flunt.Notifications;
using Flunt.Validations;

namespace UserRegistration.Domain.Commands
{
    public class DeleteUserCommand : Notifiable<Notification>, ICommand
    {
        public int Id { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract<DeleteUserCommand>()
                .AreNotEquals(0, Id, "Id", "Id inválido.")
                );
        }
    }
}

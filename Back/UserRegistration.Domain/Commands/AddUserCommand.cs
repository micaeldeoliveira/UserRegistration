using Flunt.Notifications;
using Flunt.Validations;
using UserRegistration.Domain.Enums;

namespace UserRegistration.Domain.Commands
{
    public class AddUserCommand : Notifiable<Notification>, ICommand
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public ESchooling Schooling { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract<AddUserCommand>()
              .IsNotNullOrEmpty(FirstName.Trim(), "FirstName", "Informe o nome do usuário.")
              .IsNotNullOrEmpty(LastName.Trim(), "LastName", "Informe o sobrenome do usuário.")
              .IsNotNullOrEmpty(Email.Trim(), "Email", "Informe o email do usuário.")
              .AreNotEquals(Schooling, 0, "Schooling", "Informe a escolaridade do usuário.")
              );
        }
    }
}

using UserRegistration.Domain.Contracts;
using UserRegistration.Domain.Enums;

namespace UserRegistration.Domain.Entities
{
    public class User : Entity
    {
        public User(string firstName, string lastName, string email, DateTime birthDate, ESchooling schooling)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            BirthDate = birthDate;
            Schooling = schooling;

            AddNotifications(new UserContract(this));
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public DateTime BirthDate { get; private set; }
        public ESchooling Schooling { get; private set; }

        public void Edit(string firstName, string lastName, string email, DateTime birthDate, ESchooling schooling)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            BirthDate = birthDate;
            Schooling = schooling;

            AddNotifications(new UserContract(this));
        }

    }
}

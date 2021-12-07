using Flunt.Validations;
using UserRegistration.Domain.Entities;

namespace UserRegistration.Domain.Contracts
{
    public class UserContract : Contract<User>
    {
        public UserContract(User user)
        {
            Requires()
                .IsEmail(user.Email, "Email", "Email inválido.")
                .IsGreaterOrEqualsThan(DateTime.Now.Date, user.BirthDate.Date, "BirthDate", "Data de nascimento não poder ser maior que hoje.")
                .IsLowerOrEqualsThan(1, (int)user.Schooling, "Schooling", "Escolaridade inválida (1)")
                .IsGreaterOrEqualsThan(4, (int)user.Schooling, "Schooling", "Escolaridade inválida (4)");

        }

    }
}

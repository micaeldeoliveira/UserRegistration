using Flunt.Notifications;
using UserRegistration.Domain.Commands;
using UserRegistration.Domain.Entities;
using UserRegistration.Domain.Repositories;

namespace UserRegistration.Domain.Handlers
{
    public class UserHandler : Notifiable<Notification>,
        IHandler<AddUserCommand>,
        IHandler<EditUserCommand>,
        IHandler<DeleteUserCommand>
    {
        private readonly IUserRepository _repository;

        public UserHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public Result Handle(AddUserCommand command)
        {
            command.Validate();

            if (!command.IsValid)
                return new Result
                {
                    Success = false,
                    Error = command.Notifications
                };

            var user = new User(
              command.FirstName,
              command.LastName,
              command.Email,
              command.BirthDate.Date,
              command.Schooling);

            if (!user.IsValid)
                return new Result
                {
                    Success = false,
                    Error = user.Notifications
                };

            _repository.Add(user);

            return new Result
            {
                Success = true,
                Data = user
            };

        }

        public Result Handle(EditUserCommand command)
        {
            command.Validate();

            if (!command.IsValid)
                return new Result
                {
                    Success = false,
                    Error = command.Notifications
                };

            var user = _repository.GetById(command.Id);
            if (user == null)
            {
                AddNotification("User", "Usuário não encontrado.");
                return new Result
                {
                    Success = false,
                    Error = Notifications
                };
            }

            user.Edit(
              command.FirstName,
              command.LastName,
              command.Email,
              command.BirthDate,
              command.Schooling);

            if (!user.IsValid)
                return new Result
                {
                    Success = false,
                    Error = user.Notifications
                };

            _repository.Edit(user);

            return new Result
            {
                Success = true,
                Data = user
            };
        }

        public Result Handle(DeleteUserCommand command)
        {
            command.Validate();

            if (!command.IsValid)
                return new Result
                {
                    Success = false,
                    Error = command.Notifications
                };

            var user = _repository.GetById(command.Id);
            if (user == null)
            {
                AddNotification("User", "Usuário não encontrado.");
                return new Result
                {
                    Success = false,
                    Error = Notifications
                };
            }

            _repository.Delete(user);

            return new Result
            {
                Success = true
            };
        }
    }
}

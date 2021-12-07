using UserRegistration.Domain.Commands;

namespace UserRegistration.Domain.Handlers
{
    public interface IHandler<T> where T : ICommand
    {
       Result Handle(T command);
    }
}

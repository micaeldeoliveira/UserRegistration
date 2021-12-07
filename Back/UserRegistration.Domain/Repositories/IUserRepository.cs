using UserRegistration.Domain.Entities;

namespace UserRegistration.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> GetByIdAsync(int id);
        User GetById(int id);
        void Add(User user);
        void Edit(User user);
        void Delete(User user);
    }
}

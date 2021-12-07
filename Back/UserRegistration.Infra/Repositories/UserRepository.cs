using Microsoft.EntityFrameworkCore;
using UserRegistration.Domain.Entities;
using UserRegistration.Domain.Repositories;
using UserRegistration.Infra.Contexts;

namespace UserRegistration.Infra.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetAllAsync() =>
            await _context.Users.AsNoTracking().ToListAsync();

        public async Task<User> GetByIdAsync(int id) =>
            await _context.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

        public User GetById(int id) =>
            _context.Users.FirstOrDefault(x => x.Id == id);

        public void Add(User user) =>
            _context.Users.Add(user);

        public void Edit(User user) =>
            _context.Users.Update(user);

        public void Delete(User user) =>
            _context.Users.Remove(user);

    }
}


using domain.Entities;
using domain.Interfaces.UsersInterfaces;
using Microsoft.EntityFrameworkCore;

namespace infra.Services.Users
{

    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User> FindUserByEmail(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<User> FindUserById(Guid id)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task CreateUserAsync(User user)
        {

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync(true);
        }

        public async Task DeleteUserAsync(Guid id)
        {
            await _context.Users.Where(u => u.Id == id).ExecuteDeleteAsync();
            await _context.SaveChangesAsync(true);
        }
    }
}

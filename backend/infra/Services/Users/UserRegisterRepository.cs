using domain.Entities;
using domain.Interfaces.UsersInterfaces;

namespace infra.Services.Users
{
    public class UserRegisterRepository : IUserRegisterRepository
    {
        private AppDbContext _context;

        public UserRegisterRepository(AppDbContext context)
        {
            _context = context;
        }
        public async System.Threading.Tasks.Task CreateUserAsync(User user) {
            
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync(true);
        }
    }
}

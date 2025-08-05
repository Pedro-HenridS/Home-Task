
using domain.Entities;

namespace domain.Interfaces.UsersInterfaces
{
    public interface IUserRepository
    {
        public Task<User> FindUserByEmail(string email);        
    }
}

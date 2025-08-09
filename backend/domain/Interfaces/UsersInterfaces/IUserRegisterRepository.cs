using domain.Entities;

namespace domain.Interfaces.UsersInterfaces
{
    public interface IUserRegisterRepository
    {
        public Task CreateUserAsync(User user);
    }
}

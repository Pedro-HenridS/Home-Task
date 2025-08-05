using domain.Entities;

namespace domain.Interfaces.UsersInterfaces
{
    public interface IUserRegisterRepository
    {
        public System.Threading.Tasks.Task CreateUser(User user);
    }
}

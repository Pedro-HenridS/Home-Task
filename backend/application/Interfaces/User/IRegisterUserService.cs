using domain.Entities;

namespace application.Interfaces.User
{
    public interface IRegisterUserService
    {
        public Task Execute(domain.Entities.User user);
    }
}

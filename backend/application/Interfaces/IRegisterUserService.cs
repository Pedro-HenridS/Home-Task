using domain.Entities;

namespace application.Interfaces
{
    public interface IRegisterUserService
    {
        public Task Execute(User user);
    }
}

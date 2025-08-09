using application.Interfaces;
using domain.Entities;
using domain.Interfaces.UsersInterfaces;

namespace application.Services.Account
{
    public class RegisterUserService : IRegisterUserService
    {
        public IUserRegisterRepository _userRegisterRepository;

        public RegisterUserService(IUserRegisterRepository userRegisterRepository)
        {
            _userRegisterRepository = userRegisterRepository;
        }

        public async Task Execute(User user)
        {
            
              await _userRegisterRepository.CreateUserAsync(user);
          
        }
    }
}

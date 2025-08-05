

using domain.Entities;
using domain.Interfaces.UsersInterfaces;

namespace application.Services.Account
{
    public class RegisterUserService
    {
        public IUserRegisterRepository _userRegisterRepository;

        public RegisterUserService(IUserRegisterRepository userRegisterRepository)
        {
            _userRegisterRepository = userRegisterRepository;
        }

        public async System.Threading.Tasks.Task Execute(User user)
        {
            
              await _userRegisterRepository.CreateUserAsync(user);
          
        }
    }
}



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

        public void Execute(User user)
        {
            try{
                _userRegisterRepository.CreateUser(user);
            }
            catch(Exception e)
            {

            }
            
        }
    }
}

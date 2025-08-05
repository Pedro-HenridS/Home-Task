using domain.Entities;
using domain.Interfaces.UsersInterfaces;
using Exception;
using Exception.Account;

namespace application.Services.Account
{
    public class EmailAlreadyInUseService
    {
        private IUserRepository _userRepository;

        public EmailAlreadyInUseService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> Execute(string email)
        {
            User user = await _userRepository.FindUserByEmail(email);

            if (user != null)
            {
                return true;
            }

            return false;

        }
    }
}

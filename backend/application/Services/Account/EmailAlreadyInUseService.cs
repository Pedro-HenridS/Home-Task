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

        public async void Execute(string email)
        {
            User user = await _userRepository.FindUserByEmail(email);

            if (user == null)
            {
                throw new RegisterException(ResourceErrorMessages.EMAIL_ALREADY_IN_USE);
            }

        }
    }
}

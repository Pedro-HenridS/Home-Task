using application.Interfaces;
using domain.Entities;
using domain.Interfaces.UsersInterfaces;

namespace application.Services.Account
{
    public class UserExistService : IUserExistService
    {
        private IUserRepository _userRepository;

        public UserExistService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> ByEmail(string email)
        {
            User user = await _userRepository.FindUserByEmail(email);

            if (user != null)
            {
                return false;
            }

            return true;
        }

        public async Task<bool> ById(Guid id)
        {
            User user = await _userRepository.FindUserById(id);

            if (user != null)
            {
                return false;
            }

            return true;
        }
    }
}

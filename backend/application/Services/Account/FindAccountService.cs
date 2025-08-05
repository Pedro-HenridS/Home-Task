using communication.Requests.DTO.UsersDTO;
using domain.Interfaces.UsersInterfaces;

namespace application.Services.Account
{
    public class FindAccountService
    {
        private IUserRepository _userRepository;

        public FindAccountService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void Execute(LoginDtoRequest request)
        {
            _userRepository.FindUserByEmail(request.Email);
        }
    }
}

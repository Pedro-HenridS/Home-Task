
using communication.Requests.DTO.UsersDTO;
using domain.Interfaces.UsersInterfaces;

namespace application.Services.Account
{
    public class FindAccountService
    {
        private IUserRepository _userRepository;


        public FindAccountService(
            IUserRepository userRepository
            )
        {
            _userRepository = userRepository;

        }

        public LoginJwtRequest Execute(string email)

        {
            var user = _userRepository.FindUserByEmail(email);


            return new LoginJwtRequest
            {
                Id = user.Result.Id,
                HashPassword = user.Result.Password
            };
        }
    }
}

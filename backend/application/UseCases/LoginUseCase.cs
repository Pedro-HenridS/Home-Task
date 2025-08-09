using application.Interfaces;
using application.Services.Account;
using application.Services.Encrypt;
using application.Services.Jwt;
using communication.Requests.DTO.TokenDTO;
using communication.Requests.DTO.UsersDTO;
using Exception;
using Exception.Account;

namespace application.UseCases
{
    public class LoginUseCase
    {
        private FindAccountService _accountService;
        private VerifyHashService _verifyHashService;
        private JwtService _jwtService;
        private IUserExistService _userExistService;

        public LoginUseCase(
            FindAccountService accountService,
            VerifyHashService verifyHashService,
            JwtService JwtService,
            IUserExistService userExistService
            )
        {
            _accountService = accountService;
            _verifyHashService = verifyHashService;
            _jwtService = JwtService;
            _userExistService = userExistService;
        }

        public async Task<string> Login(LoginDtoRequest request)
        {

            var searchUserResult = await _userExistService.ByEmail(request.Email);

            //Se o email não estiver salvo no banco de dados, retorna erro
            if (searchUserResult) 
            {
                throw new LoginException(ResourceErrorMessages.USER_NOT_FOUND);
            }

            LoginJwtRequest loginDto =  _accountService.Execute(request.Email);

            var passwordAnalyze = _verifyHashService.Execute(request.Password, loginDto.HashPassword);

            //Se o password estiver errado, retorna erro
            if (!passwordAnalyze)
            {
                throw new LoginException(ResourceErrorMessages.WRONG_PASSWORD);
            }

            var claim = new JwtClaimsDto
            {
                Id = loginDto.Id
            };

            return _jwtService.Execute(claim);
        }
    }
}

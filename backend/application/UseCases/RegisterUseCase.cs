using application.Services.Account;
using application.Services.Encrypt;
using application.Services.Validation;
using application.Validators;
using communication.Requests.DTO.UsersDTO;
using Exception.Account;
using FluentValidation.Results;

namespace application.UseCases
{
    public class RegisterUseCase
    {

        //converter a senha em hash
        //registrar o usuário

        private RegisterUserValidator _userValidator;
        private ValidatorService _validatorService;
        private EmailAlreadyInUseService _emailAlreadyInUseService;
        private PasswordHasherService _passwordHasherService;

        public RegisterUseCase
        (
            RegisterUserValidator userValidator,
            ValidatorService validatorService,
            EmailAlreadyInUseService EmailAlreadyInUseService,
            PasswordHasherService PasswordHasherService
        )
        {
            _userValidator = userValidator;
            _validatorService = validatorService;
            _emailAlreadyInUseService = EmailAlreadyInUseService;
            _passwordHasherService = PasswordHasherService;
        }

        public void RegisterUser(RegisterDtoRequest request)
        {
            ValidationResult validationResult = _userValidator.Validate(request);

            _validatorService.Execute<RegisterException>(validationResult);
            _emailAlreadyInUseService.Execute(request.Email);

            string passworsd = _passwordHasherService.Execute(request.Password);

        }
    }
}

using application.Services.Account;
using application.Services.Encrypt;
using application.Services.Validation;
using application.Validators;
using communication.Requests.DTO.UsersDTO;
using domain.Entities;
using Exception.Account;
using FluentValidation.Results;

namespace application.UseCases
{
    public class RegisterUseCase
    {
        private RegisterUserValidator _userValidator;
        private ValidatorService _validatorService;
        private EmailAlreadyInUseService _emailAlreadyInUseService;
        private PasswordHasherService _passwordHasherService;
        private RegisterUserService _registerUserService;

        public RegisterUseCase
        (
            RegisterUserValidator userValidator,
            ValidatorService validatorService,
            EmailAlreadyInUseService emailAlreadyInUseService,
            PasswordHasherService passwordHasherService,
            RegisterUserService registerUserService
        )
        {
            _userValidator = userValidator;
            _validatorService = validatorService;
            _emailAlreadyInUseService = emailAlreadyInUseService;
            _passwordHasherService = passwordHasherService;
            _registerUserService = registerUserService;
        }

        public void RegisterUser(RegisterDtoRequest request)
        {
            ValidationResult validationResult = _userValidator.Validate(request);

            _validatorService.Execute<RegisterException>(validationResult);
            _emailAlreadyInUseService.Execute(request.Email);

            string HashPassworsd = _passwordHasherService.Execute(request.Password);

            User user = new User { 
                
                Id = Guid.NewGuid(),
                Username = request.UserName,
                Email = request.Email,
                Password = HashPassworsd
            };

            
            _registerUserService.Execute(user);

        }
    }
}

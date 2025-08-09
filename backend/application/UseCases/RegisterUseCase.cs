using application.Interfaces;
using application.Validators;
using communication.Requests.DTO.UsersDTO;
using domain.Entities;
using Exception;
using Exception.Account;
using FluentValidation.Results;

namespace application.UseCases
{
    public class RegisterUseCase
    {
        private RegisterUserValidator _userValidator;
        private IPasswordHasherService _passwordHasherService;
        private IUserExistService _userExistService;
        private IRegisterUserService _registerUserService;

        public RegisterUseCase
        (
            RegisterUserValidator userValidator,
            IPasswordHasherService passwordHasherService,
            IUserExistService userExistService,
            IRegisterUserService registerUserService
        )
        {
            _userValidator = userValidator;
            _userExistService = userExistService;
            _passwordHasherService = passwordHasherService;
            _registerUserService = registerUserService;
        }

        public async System.Threading.Tasks.Task RegisterUser(RegisterDtoRequest request)
        {
            ValidationResult validationResult = _userValidator.Validate(request);

            // Verifica se a requisição é valida; Caso não seja retorna um erro
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                throw new RegisterException(errors);
            }

            // Verifica se o email já foi cadastrado
            var alreadyRegistered = await _userExistService.ByEmail(request.Email);
            if (alreadyRegistered)
            {
                throw new RegisterException(ResourceErrorMessages.EMAIL_ALREADY_IN_USE);
            }

            // Cria o password em forma de hash
            string HashPassword = _passwordHasherService.Execute(request.Password);

            // Criar um usuário baseado no modelo do banco
            User user = new User { 
                
                Id = Guid.NewGuid(),
                Username = request.UserName,
                Email = request.Email,
                Password = HashPassword
            };

            // Salva o usuário ao banco
            await _registerUserService.Execute(user);

        }
    }
}

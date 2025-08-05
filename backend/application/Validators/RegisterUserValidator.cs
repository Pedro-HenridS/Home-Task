using communication.Requests.DTO.UsersDTO;
using Exception;
using FluentValidation;

namespace application.Validators
{
    public class RegisterUserValidator : AbstractValidator<RegisterDtoRequest>
    {
        public RegisterUserValidator() 
        {
            RuleFor(u => u.UserName)
                .NotEmpty()
                .WithMessage(ResourceErrorMessages.EMPTY_USERNAME)
                .MinimumLength(8)
                .WithMessage(ResourceErrorMessages.LESS_THAN_8_CHAR);

            RuleFor(u => u.Email)
                .NotEmpty()
                .WithMessage(ResourceErrorMessages.EMPTY_EMAIL)
                .EmailAddress()
                .WithMessage(ResourceErrorMessages.NOT_A_EMAIL);

            RuleFor(u => u.Password).NotEmpty()
                .MinimumLength(8).WithMessage(ResourceErrorMessages.EMPTY_PASSWORD)
                .Matches("[A-Z]").WithMessage(ResourceErrorMessages.WITHOUT_CAPITALIZED_LETTER)
                .Matches("[a-z]").WithMessage(ResourceErrorMessages.WITHOUT_LOWERCASE_LETTER)
                .Matches("[0-9]").WithMessage(ResourceErrorMessages.WITHOUT_NUMBER)
                .Matches("[^a-zA-Z0-9]").WithMessage(ResourceErrorMessages.WITHOUT_SIMBOL);

            RuleFor(u => u.ConfirmedPassword)
                .Equal(u => u.Password)
                .WithMessage(ResourceErrorMessages.NOT_EQUAL_PASSWORD);
        }
    }
}

using FluentValidation.Results;

namespace application.Services.Validation
{
    public class ValidatorService
    {
        public void Execute<TException>(ValidationResult validationResult)
            where TException : System.Exception
        {
            if (!validationResult.IsValid)
            {
                var messages = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                var message = string.Join("; ", messages);

                var exception = (TException)Activator.CreateInstance(typeof(TException), message)!;

                throw exception;
            }
        }
    }
}

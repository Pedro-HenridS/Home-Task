namespace Exception.Account
{
    public class RegisterException : ApiException
    {
        public List<string> Errors = [];

        public RegisterException(string error)
        {
            Errors = [error];
        }

        public RegisterException(List<string> errors) 
        {
            Errors = errors;
        }
    }
}

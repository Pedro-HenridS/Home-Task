namespace Exception.Account
{
    public class LoginException : ApiException
    {
        public List<string> Errors = [];

        public LoginException(string error)
        {
            Errors = [error];
        }

        public LoginException(List<string> errors) 
        {
            Errors = errors;
        }
    }
}

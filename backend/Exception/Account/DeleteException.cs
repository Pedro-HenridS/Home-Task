
namespace Exception.Account
{
    public class DeleteException : ApiException
    {
        public List<string> Errors = [];

        public DeleteException(string error)
        {
            Errors = [error];
        }

        public DeleteException(List<string> errors) 
        {
            Errors = errors;
        }
    }
}

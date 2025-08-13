
namespace Exception.Friend
{
    public class AddTasksException : ApiException
    {

        public List<string> Errors = [];

        public AddTasksException(string error)
        {
            Errors = [error];
        }

        public AddTasksException(List<string> errors)
        {
            Errors = errors;
        }
        
    }
}

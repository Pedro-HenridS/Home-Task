
namespace Exception.Friend
{
    public class FriendshipException : ApiException
    {

        public List<string> Errors = [];

        public FriendshipException(string error)
        {
            Errors = [error];
        }

        public FriendshipException(List<string> errors)
        {
            Errors = errors;
        }
        
    }
}

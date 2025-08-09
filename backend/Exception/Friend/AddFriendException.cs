namespace Exception.Friend
{
    public class AddFriendException : ApiException
    {
        public List<string> Errors = [];

        public AddFriendException(string error)
        {
            Errors = [error];
        }

        public AddFriendException(List<string> errors)
        {
            Errors = errors;
        }
    }
}

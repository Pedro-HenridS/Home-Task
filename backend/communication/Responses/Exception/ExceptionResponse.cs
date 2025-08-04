namespace communication.Responses.Exception
{
    public class ExceptionResponse
    {
        public List<string> Errors { get; set; } = [];

        public ExceptionResponse(string error)
        {
            Errors = [error];
        }

        public ExceptionResponse(List<string> errors)
        {
            Errors = errors;
        }
    }
}

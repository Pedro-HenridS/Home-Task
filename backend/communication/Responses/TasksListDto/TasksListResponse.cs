using communication.Interfaces.TasksDto;

public class TasksListResponse()
{
    public bool Sucess { get; set; }
    public List<Tasks> Data { get; set; }
    public string Message { get; set; } = string.Empty;
    public List<string> Errors { get; set; }

}
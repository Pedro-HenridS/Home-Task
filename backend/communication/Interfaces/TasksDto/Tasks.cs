
using communication.Enums;

namespace communication.Interfaces.TasksDto;
public class Tasks
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime Due { get; set; }
    public Guid Group_Id { get; set; }
    public StatusEnum Status { get; set; }
}
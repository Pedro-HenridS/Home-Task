using communication.Enums;

namespace communication.Requests.DTO.TasksDto
{
    public class CreateTaskDTO
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public DateTime Due { get; set; }
        public Guid Group_Id { get; set; }
        public StatusEnum Status { get; set; }
    }
}

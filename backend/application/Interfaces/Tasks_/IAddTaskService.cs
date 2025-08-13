using communication.Requests.DTO.TasksDto;

namespace application.Interfaces.Tasks_
{
    public interface IAddTaskService
    {
        public Task AddTask(CreateTaskDTO taskDto);
    }
}

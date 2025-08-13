using communication.Requests.DTO.UserTaskDTO;

namespace application.Interfaces.UserTask
{
    public interface IAddUserTaskService
    {
        public Task AddUserTask(UserTaskDto user_task);
    }
}

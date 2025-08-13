

using application.Interfaces.UserTask;
using communication.Requests.DTO.UserTaskDTO;
using domain.Entities;
using domain.Interfaces.UserTask;

namespace application.Services.UserTask
{
    public class AddUserTaskService : IAddUserTaskService
    {
        IUserTaskRepository _userTaskRepository;
        public AddUserTaskService(

           IUserTaskRepository userTaskRepository
        ) 
        {
          _userTaskRepository = userTaskRepository;
        }
        public async Task AddUserTask(UserTaskDto request)
        {
            User_Task user_task = new User_Task
            {
                Id = Guid.NewGuid(),
                UserId = request.UserId,
                TaskId = request.TaskId
            };

            await _userTaskRepository.AddUserTask(user_task);
        }
    }
}

using application.Interfaces.Tasks_;
using domain.Interfaces.TasksInterfaces;
using domain.Interfaces.UserTask;

namespace application.Services.Tasks_
{
    public class TaskExistService : ITaskExistService
    {
        ITasksRespository _userTaskRepository;
        public TaskExistService(

           ITasksRespository userTaskRepository
        )
        {
            _userTaskRepository = userTaskRepository;
        }

        public async Task<bool> Execute(Guid taskId)
        {
            var task = await _userTaskRepository.GetTask(taskId);

            if (task == null) { 
                return false;
            }

            return true;
        }
    }
}

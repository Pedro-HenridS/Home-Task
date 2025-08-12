using application.Interfaces;
using domain.Entities;
using domain.Interfaces.TasksInterfaces;

namespace application.Services.Tasks_
{
    public class GetAllTasksService : IGetAllTasks
    {
        private ITasksRespository _tasksRespository;

        public GetAllTasksService(
            ITasksRespository tasksRespository
        ) {
            _tasksRespository = tasksRespository;
        }
        public async Task<List<Tasks>> GetByUserId(Guid id) 
        { 
            List<Tasks> tasks = await _tasksRespository.GetTasksByUser(id);

            return tasks;
        }
    }
}

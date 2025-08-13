using domain.Entities;

namespace domain.Interfaces.TasksInterfaces
{
    public interface ITasksRespository
    {
        // public Task<List<Tasks>> GetTasksByGroup(Guid groupId);
        public Task<List<Tasks>> GetTasksByUser(Guid UserId);

        public Task AddTask(Tasks task);
        public Task<Tasks> GetTask(Guid TaskId);
    }
}
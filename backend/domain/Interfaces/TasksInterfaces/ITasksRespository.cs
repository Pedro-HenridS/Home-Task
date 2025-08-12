using domain.Entities;

namespace domain.Interfaces.TasksInterfaces
{
    public interface ITasksRespository
    {
        // public Task<List<Tasks>> GetTasksByGroup(Guid groupId);
        public Task<List<Tasks>> GetTasksByUser(Guid UserId);

        public Task AddTaskWithuser();
    }
}
using domain.Entities;

namespace domain.Interfaces.TasksInterfaces
{
    public interface ITasksRespository
    {
        public Task<List<Friends>> GetFriendsByGroup(Guid groupId);
        public Task<List<Friends>> GetFriendsByUser(Guid UserId);
    }
}

using domain.Entities;

namespace domain.Interfaces.UserTask
{
    public interface IUserTaskRepository
    {
        public Task AddUserTask(User_Task users_tasks);
    }
}

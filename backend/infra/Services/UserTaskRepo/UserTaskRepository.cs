using domain.Entities;
using domain.Interfaces.UserTask;

namespace infra.Services.UserTaskRepo
{
    public class UserTaskRepository : IUserTaskRepository
    {
        private AppDbContext _context;

        public UserTaskRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddUserTask(User_Task user_task)
        {
            await _context.User_Task.AddAsync(user_task);
            await _context.SaveChangesAsync();
        }
    }
}

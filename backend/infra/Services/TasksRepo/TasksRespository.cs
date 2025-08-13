using domain.Entities;
using domain.Interfaces.TasksInterfaces;
using Microsoft.EntityFrameworkCore;

namespace infra.Services.TasksRepo
{
    public class TasksRespository : ITasksRespository
    {
        private AppDbContext _context;

        public TasksRespository(AppDbContext context)
        {
            _context = context;
        }

        //public async Task<List<Task>> GetTasksByGroup(Guid groupId)
        //{
        //    return await 
        //}

        public async Task<List<Tasks>> GetTasksByUser(Guid userId)
        {
            List<Tasks> result = await _context.User_Task
                .Where(ut => ut.UserId == userId)
                .Include(ut => ut.Task)  
                .Select(ut => ut.Task)
                .ToListAsync();

            return result;
        }

        public async Task AddTask(Tasks task)
        {
            await _context.Tasks.AddAsync(task);
            await _context.SaveChangesAsync();
        }

        public async Task<Tasks> GetTask(Guid TaskId)
        {
            return await _context.Tasks.Where(t => t.Id == TaskId).FirstOrDefaultAsync();

        }
    }
}


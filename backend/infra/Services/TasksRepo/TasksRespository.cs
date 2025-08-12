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
                .Select(ut => ut.Task)
                .ToListAsync();

            return result;
        }
    }
}


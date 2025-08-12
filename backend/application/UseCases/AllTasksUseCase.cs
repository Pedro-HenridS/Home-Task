using application.Interfaces;
using domain.Entities;

namespace application.UseCases
{
    public class AllTasksUseCase
    {
        private IGetAllTasks _getAllTasks;

        public AllTasksUseCase(
            IGetAllTasks getAllTasks
        ) 
        {
            _getAllTasks = getAllTasks;
        }

        public async Task<List<Tasks>> GetAllTasksById(Guid id)
        {
            return await _getAllTasks.GetByUserId(id);
        }
    }
}

using domain.Entities;

namespace application.Interfaces
{
    public interface IGetAllTasks
    {
        public Task<List<Tasks>> GetByUserId(Guid userId);
    }
}

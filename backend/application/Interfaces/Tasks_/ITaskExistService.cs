

namespace application.Interfaces.Tasks_
{
    public interface ITaskExistService
    {
        public Task<bool> Execute(Guid user);
    }
}

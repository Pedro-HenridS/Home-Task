namespace application.Interfaces.User
{
    public interface IDeleteUserService
    {
        public Task Delete(Guid id);
    }
}

namespace application.Interfaces.User
{
    public interface IUserExistService
    {
        public Task<bool> ByEmail(string email);
        public Task<bool> ById(Guid email);
    }
}

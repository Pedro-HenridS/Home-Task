namespace application.Interfaces
{
    public interface IPasswordHasherService
    {
        public string Execute(string password);
    }
}

namespace domain.Interfaces.Encrypt
{
    public interface IPasswordHasher
    {
        public string PasswordHash(string password);
    }
}



using domain.Interfaces.Encrypt;

namespace infra.Services.Encrypt
{
    public class PasswordHasher : IPasswordHasher
    {
        public string PasswordHash(string password)
        {
            var passwordHash = BCrypt.Net.BCrypt.HashPassword(password);
            return passwordHash;
        }
    }
}

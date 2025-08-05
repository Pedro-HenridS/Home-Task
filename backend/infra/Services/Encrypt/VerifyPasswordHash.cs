
using domain.Interfaces.Encrypt;

namespace infra.Services.Encrypt
{
    public class VerifyPasswordHash : IVerifyPasswordHash
    {

        public bool Verify(string password, string hash)
        {
            return BCrypt.Net.BCrypt.Verify(password, hash);
        }
    }
}

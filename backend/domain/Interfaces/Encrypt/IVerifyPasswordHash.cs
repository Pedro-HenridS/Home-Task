
namespace domain.Interfaces.Encrypt
{
    public interface IVerifyPasswordHash
    {
        bool Verify(string password, string hash);
    }
}

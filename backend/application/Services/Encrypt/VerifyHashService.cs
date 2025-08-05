using domain.Interfaces.Encrypt;
using Exception;
using Exception.Account;

namespace application.Services.Encrypt
{
    public class VerifyHashService
    {
        IVerifyPasswordHash _verifyPasswordHash;

        public VerifyHashService(IVerifyPasswordHash verifyPasswordHash)
        {
            _verifyPasswordHash = verifyPasswordHash;
        }

        public bool Execute(string password, string hash) 
        {
            if(!_verifyPasswordHash.Verify(password, hash))
            {
                return false;
            }

            return true;
        }
    }
}

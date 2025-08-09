

using application.Interfaces;
using domain.Interfaces.Encrypt;

namespace application.Services.Encrypt
{
    public class PasswordHasherService : IPasswordHasherService
    {
        private IPasswordHasher _passwordHasher;

        public PasswordHasherService( IPasswordHasher passwordHasher ) 
        {
            _passwordHasher = passwordHasher;
        }

        public string Execute(string password) {
        
            return _passwordHasher.PasswordHash( password );
        }

    }
}

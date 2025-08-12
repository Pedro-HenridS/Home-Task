using application.Interfaces.User;
using domain.Interfaces.UsersInterfaces;

namespace application.Services.Account
{
    public class DeleteUserService : IDeleteUserService
    {
        public IUserRepository _userRegisterRepository;

        public DeleteUserService(IUserRepository userRegisterRepository)
        {
            _userRegisterRepository = userRegisterRepository;
        }

        public async Task Delete(Guid id)
        {
            
              await _userRegisterRepository.DeleteUserAsync(id);
          
        }
    }
}

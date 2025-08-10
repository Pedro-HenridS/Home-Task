
using application.Interfaces;
using Exception;
using Exception.Account;

namespace application.UseCases
{
    public class DeleteUseCase
    {
        private IUserExistService _userExistService;
        private IDeleteUserService _deleteUserService;
        public DeleteUseCase(
            IUserExistService userExistService,
            IDeleteUserService deleteUserService
        )
        {
            _userExistService = userExistService;
            _deleteUserService = deleteUserService;
        }

        public async Task Delete(Guid id)
        {
            var result = await _userExistService.ById(id);

            if (!result)
            {

                throw new DeleteException(ResourceErrorMessages.USER_NOT_FOUND);
            }

            await _deleteUserService.Delete(id);
        }
        //receber um id
        //verificar se o id existe
        //Excluir o usuário
    }   
}
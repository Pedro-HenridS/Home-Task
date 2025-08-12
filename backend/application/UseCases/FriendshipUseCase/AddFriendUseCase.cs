using application.Interfaces;
using application.Interfaces.User;
using communication.Requests.DTO.UsersDTO;
using domain.Entities;
using domain.Interfaces.Friends_Interfaces;
using Exception;
using Exception.Friend;

namespace application.UseCases.FriendshipUseCase
{
    public class AddFriendUseCase
    {
        private IUserExistService _userExistService;
        private IFindFriendshipService _findFriendshipService;
        private IFriendsRepositories _friendsRepositories;
        public AddFriendUseCase(
            IUserExistService userExistService,
            IFindFriendshipService findFriendshipService,
            IFriendsRepositories friendsRepositories
            ) 
        {
            _userExistService = userExistService;
            _findFriendshipService = findFriendshipService;
            _friendsRepositories = friendsRepositories;
        }

        public async Task AddFriend(AddFriendDtoRequest request)
        {
            if (await _userExistService.ById(request.FriendId))
            {
                new AddFriendException(ResourceErrorMessages.USER_NOT_FOUND);
            }

            Console.Write(request.UserId.ToString(), request.FriendId.ToString());
            // Aqui
            var verifyFriendship = await _findFriendshipService.FriendshipExist(request.UserId, request.FriendId);
            
            if (verifyFriendship)
            {
                throw new AddFriendException("Amizade já existe");
            }

            var friendship = new Friends
            {
                Id = Guid.NewGuid(),
                User1_Id = request.UserId,
                User2_Id = request.FriendId
            };

            if(request.UserId > request.FriendId)
            {
                friendship = new Friends
                {   
                    Id = Guid.NewGuid(),
                    User1_Id = request.FriendId,
                    User2_Id = request.UserId
                };
            }

            await _friendsRepositories.AddFriendship(friendship);


        }
    }
}

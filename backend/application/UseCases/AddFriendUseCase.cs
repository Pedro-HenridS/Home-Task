using application.Interfaces;
using communication.Requests.DTO.UsersDTO;
using domain.Entities;
using domain.Interfaces.Friends_Interfaces;
using Exception;
using Exception.Friend;

namespace application.UseCases
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
            if (!await _userExistService.ById(request.FriendId))
            {
                new AddFriendException(ResourceErrorMessages.USER_NOT_FOUND);
            }

            if(await _findFriendshipService.FriendshipExist(request.UserId, request.FriendId))
            {
                new AddFriendException("Amizade já existe");
            }

            var friendship = new Friends
            {
                Id = new Guid(),
                User1_Id = request.UserId,
                User2_Id = request.FriendId
            };

            if(request.UserId > request.FriendId)
            {
                friendship = new Friends
                {
                    User1_Id = request.FriendId,
                    User2_Id = request.UserId
                };
            }

            _friendsRepositories.AddFriendship(friendship);


        }
    }
}

using application.Interfaces;
using domain.Entities;
using domain.Interfaces.Friends_Interfaces;
using Exception;
using Exception.Friend;

namespace application.Services.Account
{
    public class FindFriendshipService : IFindFriendshipService
    {
        public IFriendsRepositories _friendsRepositories;

        public FindFriendshipService(
         IFriendsRepositories friendsRepositories
        )
        {
            _friendsRepositories = friendsRepositories;
        }

        public async Task<List<Friends>> AllFriends(Guid userId)
        {
            var friends = await _friendsRepositories.AllFriends(userId);

            if (friends == null)
            {
                throw new FriendshipException("Nenhum amigo encontrado");
            }

            return friends;
        }

        public async Task<bool> FriendshipExist(Guid userId, Guid friendId)
        {
            var friend = await _friendsRepositories.SearchFriend(userId, friendId);

            if (friend == null)
            {
                return false;
            }

            return true;
        }
    }
}

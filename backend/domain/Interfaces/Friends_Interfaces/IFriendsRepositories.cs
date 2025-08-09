using domain.Entities;

namespace domain.Interfaces.Friends_Interfaces
{
    public interface IFriendsRepositories
    {
        public Task<Friends> SearchFriend(Guid userId, Guid friendId);
        public Task<List<Friends>> AllFriends(Guid userId);
        public Task AddFriendship(Friends friends);
    }
}

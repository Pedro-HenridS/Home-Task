using domain.Entities;

namespace application.Interfaces
{
    public interface IFindFriendshipService
    {
        public Task<List<Friends>> AllFriends(Guid userId);
        public Task<bool> FriendshipExist(Guid userId, Guid friendId);
    }
}

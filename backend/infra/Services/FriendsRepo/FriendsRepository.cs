using domain.Entities;
using domain.Interfaces.Friends_Interfaces;
using Microsoft.EntityFrameworkCore;

namespace infra.Services.FriendsRepo
{
    public class FriendsRepository : IFriendsRepositories
    {
        private AppDbContext _context;

        public FriendsRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Friends>> AllFriends(Guid userId)
        {

            var result = await _context.Friends
                .Where(f => f.User1_Id == userId || f.User2_Id == userId)
                .ToListAsync();

            return result;
        }
        public async Task<Friends> SearchFriend(Guid userId, Guid friendId)
        {   
            var bothId = new { userId, friendId };
            if (userId < friendId)
            {
                bothId = new { userId, friendId };
            }

            var result = await _context.Friends.FirstOrDefaultAsync(f => new { f.User1_Id, f.User2_Id }.Equals(bothId));

            return  result;
        }
        public async void AddFriendship(Friends friends)
        {
            _context.Friends.AddAsync(friends);
            _context.SaveChangesAsync();
        }
    }
}

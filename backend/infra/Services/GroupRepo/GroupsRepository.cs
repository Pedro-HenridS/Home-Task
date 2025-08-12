using domain.Entities;
using domain.Interfaces.Groups;

namespace infra.Services.GroupRepo
{
    public class GroupsRepository : IGroupsRepository
    {
        private AppDbContext _context;

        public GroupsRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddGroup(Group group)
        {
            await _context.Groups.AddAsync(group);
            await _context.SaveChangesAsync();

        }
    }
}

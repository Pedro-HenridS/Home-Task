using domain.Entities;
using domain.Interfaces.Groups;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

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

        public async Task<Group> GetGroup(Guid id)
        {
            return await _context.Groups.Where(g => g.Id == id).FirstOrDefaultAsync();
        }
    }
}

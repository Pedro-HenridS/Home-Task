using domain.Entities;

namespace domain.Interfaces.Groups
{
    public interface IGroupsRepository
    {
        public Task AddGroup(Group group);

    }
}

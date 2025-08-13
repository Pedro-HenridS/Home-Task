using application.Interfaces.Group;
using domain.Interfaces.Groups;

namespace application.Services.Groups
{
    public class GroupExistService : IGroupExistService
    {
        private IGroupsRepository _groupsRepository;
        public GroupExistService(
            IGroupsRepository groupsRepository
        )
        {
            _groupsRepository = groupsRepository;
        }

        public async Task<bool> GroupExist(Guid groupId)
        {
            var result = await _groupsRepository.GetGroup(groupId);

            if (result == null) 
            {
                return false;
            }

            return true;
        }
    }
}

using application.Interfaces.Group;
using communication.Requests.DTO.GroupsDTO;
using domain.Entities;
using domain.Interfaces.Groups;

namespace application.Services.Groups
{
    public class AddGroupService : IAddGroupService
    {
        private IGroupsRepository _groupsRepository;
        public AddGroupService(
            IGroupsRepository groupsRepository
        )
        {
            _groupsRepository = groupsRepository;
        }

        public async Task AddGroup(AddGroupDTO groupDto)
        {
            Group group = new Group
            {
                Id = Guid.NewGuid(),
                Name = groupDto.Name,
                Icon = System.Text.Encoding.UTF8.GetBytes(groupDto.Icon)
            };

            await _groupsRepository.AddGroup(group);
        }
    }
}

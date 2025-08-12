using communication.Requests.DTO.GroupsDTO;

namespace application.Interfaces.Group
{
    public interface IAddGroupService
    {
        public Task AddGroup(AddGroupDTO group);
    }
}

using application.Interfaces.Group;
using communication.Requests.DTO.GroupsDTO;


namespace application.UseCases.GroupUseCase
{
    public class AddGroupUseCase 
    {
        private IAddGroupService _groupsService;
        public AddGroupUseCase(
            IAddGroupService groupsService
        ) 
        {
            _groupsService = groupsService;
        }
        public async Task AddGroup(AddGroupDTO groupDto)
        {

            await _groupsService.AddGroup( groupDto );


        }
    }
}

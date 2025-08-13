using application.Interfaces.Group;
using application.Interfaces.Tasks_;
using communication.Requests.DTO.TasksDto;
using Exception;
using Exception.Friend;

namespace application.UseCases.TasksUseCase
{
    public class AddTaskUseCase
    {
        private IAddTaskService _addTaskService;
        private IGroupExistService _groupExistService;

        public AddTaskUseCase(
            IAddTaskService addTaskService,
            IGroupExistService groupExistService
        ) 
        {
            _addTaskService = addTaskService;
            _groupExistService = groupExistService;
        }
        public async Task AddTask(CreateTaskDTO request)
        {
            var groupExist = await _groupExistService.GroupExist(request.Group_Id);

            if (!groupExist){

                throw new AddTasksException(ResourceErrorMessages.GROUP_NOT_FOUND);
            }
            await _addTaskService.AddTask( request );
        }
    }
}

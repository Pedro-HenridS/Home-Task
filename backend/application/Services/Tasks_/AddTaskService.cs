using application.Interfaces.Tasks_;
using communication.Requests.DTO.TasksDto;
using domain.Entities;
using domain.Enums;
using domain.Interfaces.TasksInterfaces;

namespace application.Services.Tasks_
{
    public class AddTaskService : IAddTaskService
    {
        private ITasksRespository _tasksRespository;
        public AddTaskService(
            ITasksRespository tasksRespository
        ) 
        {
            _tasksRespository = tasksRespository;
        }

        public async Task AddTask(CreateTaskDTO taskDto)
        {

            Tasks task = new Tasks
            {
                Id = Guid.NewGuid(),
                Name = taskDto.Name,
                Description = taskDto.Description,
                Due = taskDto.Due,
                Group_Id = taskDto.Group_Id,
                Status = (StatusEnum)taskDto.Status,
            };

            await _tasksRespository.AddTask(task);
        }
    }

}

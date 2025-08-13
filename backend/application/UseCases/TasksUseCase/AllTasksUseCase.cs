using application.Interfaces;
using communication.Interfaces.TasksDto;
using Exception;

namespace application.UseCases.TasksUseCase
{
    public class AllTasksUseCase
    {
        private IGetAllTasks _getAllTasks;

        public AllTasksUseCase(
            IGetAllTasks getAllTasks
        )
        {
            _getAllTasks = getAllTasks;
        }

        public async Task<TasksListResponse> GetAllTasksById(Guid id)
        {
            var tasks = await _getAllTasks.GetByUserId(id);
            List<Tasks> tasks_list = [];

            foreach (var t in tasks)
            {
                Tasks item = new()
                {
                    Id = t.Id,
                    Name = t.Name,
                    Description = t.Description,
                    Due = t.Due,
                    Group_Id = t.Group_Id,
                    Status = (communication.Enums.StatusEnum)t.Status
                };

                tasks_list.Add(item);
            }

            if (tasks == null)
            {
                TasksListResponse response = new()
                {
                    Sucess = false,
                    Data = null,
                    Message = "",
                    Errors = []
                };

                return response;
            }
            else
            {
                TasksListResponse response = new()
                {
                    Sucess = true,
                    Data = tasks_list,
                    Message = "",
                    Errors = []
                };
                return response;
            }

        }
    }
}

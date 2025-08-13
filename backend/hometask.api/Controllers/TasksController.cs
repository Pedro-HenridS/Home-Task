
using System.Security.Claims;
using application.UseCases.TasksUseCase;
using communication.Requests.DTO.TasksDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace hometask.api.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private AddTaskUseCase _addTaskUseCase;
        private AllTasksUseCase _allTasksUseCase;
        public TasksController(
         AddTaskUseCase addTaskUseCase,
         AllTasksUseCase allTasksUseCase
        )
        {
            _addTaskUseCase = addTaskUseCase;
            _allTasksUseCase = allTasksUseCase;
        }

        [Authorize]
        [HttpGet]
        [Route("/all")]
        public async Task<IActionResult> GetTasks()
        {
            Guid userId = new Guid(User.FindFirst(ClaimTypes.NameIdentifier)?.Value!);

            var response = await _allTasksUseCase.GetAllTasksById(userId);

            return Ok(response);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddTask([FromBody] CreateTaskDTO request)
        {
            await _addTaskUseCase.AddTask(request);

            

            return Ok("");
        }
    }
}


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
        AddTaskUseCase _addTaskUseCase;
        public TasksController(
         AddTaskUseCase addTaskUseCase
        ) 
        {
            _addTaskUseCase = addTaskUseCase;
        }

        [Authorize]
        [HttpGet]
        public IActionResult Home()
        {
            var message = "Testando batata";
            return Ok( new { message });
        }

        //[Authorize]
        [HttpPost]
        public async Task<IActionResult> AddTask([FromBody] CreateTaskDTO request)
        {
            await _addTaskUseCase.AddTask(request);

            

            return Ok("");
        }
    }
}

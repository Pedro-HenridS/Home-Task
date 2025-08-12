
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace hometask.api.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        [Authorize]
        [HttpGet]
        public IActionResult Home()
        {
            var message = "Testando batata";
            return Ok( new { message });
        }
    }
}

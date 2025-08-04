using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace hometask.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        [HttpGet]
        [Route("login")]
        public IActionResult teste(string teste)
        {
            return Ok("teste");
        }
    }
}

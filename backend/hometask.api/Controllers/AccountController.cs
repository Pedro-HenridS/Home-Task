using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace hometask.api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        [HttpPost]
        [Route("login")]
        public IActionResult Login(string teste)
        {
            return Ok("teste");
        }

        [HttpPost]
        [Route("register")]
        public IActionResult Register([FromBody] ) 
        {
        
        }
    }
}

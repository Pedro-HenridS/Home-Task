using application.UseCases;
using communication.Requests.DTO.UsersDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace hometask.api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        public RegisterUseCase _registerUseCase;

        public AccountController(RegisterUseCase registerUseCase) 
        {
            _registerUseCase = registerUseCase;
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login(string teste)
        {
            return Ok("teste");
        }

        [HttpPost]
        [Route("register")]
        public IActionResult Register([FromBody] RegisterDtoRequest request)
        {
            _registerUseCase.RegisterUser(request);

            return Created();
        }  
    }
}

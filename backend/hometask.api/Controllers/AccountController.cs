using application.UseCases;
using communication.Requests.DTO.UsersDTO;
using Microsoft.AspNetCore.Mvc;

namespace hometask.api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    
    
    public class AccountController : ControllerBase
    {
        public RegisterUseCase _registerUseCase;
        public LoginUseCase _loginUseCase;

        public AccountController(
            RegisterUseCase registerUseCase,
            LoginUseCase loginUseCase
            ) 
        {
            _registerUseCase = registerUseCase;
            _loginUseCase = loginUseCase;
        }

        

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDtoRequest request)
        {
            await _registerUseCase.RegisterUser(request);

            return Created();
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginDtoRequest request)
        {
            string token = await _loginUseCase.Login(request);

            return Ok(token);
        }
    }
}

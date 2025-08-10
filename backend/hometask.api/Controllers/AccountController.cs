using application.UseCases;
using communication.Requests.DTO.UsersDTO;
using Microsoft.AspNetCore.Mvc;

namespace hometask.api.Controllers
{
    [Route("[controller]")]
    [ApiController]


    public class AccountController : ControllerBase
    {
        private RegisterUseCase _registerUseCase;
        private LoginUseCase _loginUseCase;
        private DeleteUseCase _deleteUseCase;

        public AccountController(
            RegisterUseCase registerUseCase,
            LoginUseCase loginUseCase,
            DeleteUseCase deleteUseCase
            )
        {
            _registerUseCase = registerUseCase;
            _loginUseCase = loginUseCase;
            _deleteUseCase = deleteUseCase;
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
        public async Task<IActionResult> Login([FromBody] LoginDtoRequest request)
        {
            string token = await _loginUseCase.Login(request);

            return Ok(token);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            await _deleteUseCase.Delete(id);   
            return Ok();
        }
    }
}

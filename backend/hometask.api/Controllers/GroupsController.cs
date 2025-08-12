using application.UseCases.GroupUseCase;
using communication.Requests.DTO.GroupsDTO;
using Microsoft.AspNetCore.Mvc;

namespace hometask.api.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class GroupsController : ControllerBase
    {

        private AddGroupUseCase _addGroupUseCase;

        public GroupsController(
            AddGroupUseCase addGroupUseCase
        )
        {
            _addGroupUseCase = addGroupUseCase;
        }

        [HttpPost]
        public async Task<IActionResult> AddGroup([FromBody] AddGroupDTO group)
        {
            try
            {
                await _addGroupUseCase.AddGroup(group);
                return Ok("");
            }
            catch (System.Exception err)
            {
                Console.WriteLine(err);
                return BadRequest(err);
            }
            

            
        }
    }
}

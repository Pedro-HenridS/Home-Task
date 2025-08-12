using application.UseCases.FriendshipUseCase;
using communication.Requests.DTO.UsersDTO;
using Microsoft.AspNetCore.Mvc;

namespace hometask.api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FriendsController : ControllerBase
    {
        public AddFriendUseCase _addFriendUseCase;

        public FriendsController(
            AddFriendUseCase addFriendUseCase
        ) 
        {
            _addFriendUseCase = addFriendUseCase;
        }

        [HttpPost]
        [Route("/addfriend")]
        
        public async Task<IActionResult> AddFriend([FromBody] AddFriendDtoRequest request)
        {
            await _addFriendUseCase.AddFriend(request);

            return Ok();
        }
    }
}

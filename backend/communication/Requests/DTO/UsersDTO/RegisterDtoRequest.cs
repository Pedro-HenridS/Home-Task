
namespace communication.Requests.DTO.UsersDTO
{
    public class RegisterDtoRequest
    {
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string ConfirmedPassword { get; set; } = string.Empty;
    }
}

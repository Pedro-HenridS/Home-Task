

namespace communication.Requests.DTO.UsersDTO
{
    public class LoginJwtRequest
    {
        public Guid Id { get; set; }
        public string HashPassword { get; set; } = string.Empty;
    }
}

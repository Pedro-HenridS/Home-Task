namespace communication.Requests.DTO.UsersDTO
{
    public class AddFriendDtoRequest
    {
        public Guid UserId { get; set; }
        public Guid FriendId { get; set; }
    }
}

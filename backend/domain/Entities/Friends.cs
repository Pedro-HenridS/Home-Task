using System.ComponentModel.DataAnnotations.Schema;

namespace domain.Entities
{
    public class Friends
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid FriendId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        [ForeignKey("FriendId")]
        public User Friend { get; set; }
    }
}

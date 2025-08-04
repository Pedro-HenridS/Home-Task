using System.ComponentModel.DataAnnotations.Schema;

namespace domain.Entities
{
    public class Membering
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid GroupId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        [ForeignKey("GroupId")]
        public Group Group { get; set; }
    }
}

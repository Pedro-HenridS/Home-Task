using System.ComponentModel.DataAnnotations.Schema;

namespace domain.Entities
{
    public class Friends
    {
        public Guid Id { get; set; }
        public Guid User1_Id { get; set; }
        public Guid User2_Id { get; set; }

        [ForeignKey("User1_Id")]
        public User User1 { get; set; } = new User();

        [ForeignKey("User2_Id")]
        public User User2 { get; set; } = new User();
    }
}

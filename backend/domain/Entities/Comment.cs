
using System.ComponentModel.DataAnnotations.Schema;

namespace domain.Entities
{
    public class Comment
    {
        public Guid Id { get; set; }
        public Guid User_Task_Id { get; set; }
        public string Img_bin { get; set; } = string.Empty;

        [ForeignKey("User_Task_Id")]
        public User_Task User_Task { get; set; }
    }
}



using System.ComponentModel.DataAnnotations.Schema;

namespace domain.Entities
{
    public class Image
    {
        public Guid Id { get; set; }
        public Guid User_Task_Id { get; set; }
        public Byte[] Img_bin { get; set; }

        [ForeignKey("User_Task_Id")]
        public User_Task User_Task { get; set; }
    }
}

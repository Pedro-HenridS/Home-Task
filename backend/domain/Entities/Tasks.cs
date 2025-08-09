using System.ComponentModel.DataAnnotations.Schema;
using domain.Enums;

namespace domain.Entities
{
    public class Tasks
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime Due { get; set; }
        public  Guid Group_Id { get; set; }
        public StatusEnum Status { get; set; }

        [ForeignKey("Group_Id")]
        public Group Group { get; set; }
        public ICollection<User_Task> User_Task { get; set; }


    }
}

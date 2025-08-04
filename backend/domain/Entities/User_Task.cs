using System.ComponentModel.DataAnnotations.Schema;

namespace domain.Entities
{
    public class User_Task
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid TaskId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        [ForeignKey("TaskId")]
        public Task Task { get; set; }

        public ICollection<Image> Image { get; set; }
        public ICollection<Comment> Comment { get; set; }
    }
}

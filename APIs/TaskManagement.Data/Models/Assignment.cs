using TaskManagement.Data.Enums;

namespace TaskManagement.Data.Models
{
    public class Assignment
    {
        public Assignment()
        {
            Comments = new HashSet<Comment>();
            Attachments = new HashSet<Attachment>();
        }
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public Priority Priority { get; set; }
        public Status Status { get; set; }
        public DateTime DueDate { get; set; }
        public int UserId { get; set; }
        public virtual User? User { get; set; }
        public int ProjectId { get; set; }
        public virtual Project? Project { get; set; }
        public virtual ICollection<Comment>? Comments { get; set; }
        public virtual ICollection<Attachment>? Attachments { get; set; }
    }
}

using TaskManagement.Data.Enums;

namespace TaskManagement.Data.Models
{
    public class Assignment
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public Priority Priority { get; set; }
        public Status Status { get; set; }
        public DateTime DueDate { get; set; }
        public int AppUserId { get; set; }
        public virtual AppUser? User { get; set; }
        public int ProjectId { get; set; }
        public virtual Project? Project { get; set; }
    }
}

namespace TaskManagement.Data.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string? Content { get; set; }
        public DateTime TimeStamp { get; set; } = DateTime.Now;
        public int UserId { get; set; }
        public virtual User? User { get; set; }
        public int AssignmentId { get; set; }
        public virtual Assignment? Assignment { get; set; }
    }
}

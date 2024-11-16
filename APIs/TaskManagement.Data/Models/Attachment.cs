namespace TaskManagement.Data.Models
{
    public class Attachment
    {
        public int Id { get; set; }
        public string? PublicId { get; set; }
        public string? FilePath { get; set; }
        public DateTime TimeStamp { get; set; } = DateTime.Now;
        public int UserId { get; set; }
        public virtual User? User { get; set; }
        public int AssignmentId { get; set; }
        public virtual Assignment? Assignment { get; set; }
    }
}

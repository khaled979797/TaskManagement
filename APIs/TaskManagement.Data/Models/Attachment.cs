namespace TaskManagement.Data.Models
{
    public class Attachment
    {
        public int Id { get; set; }
        public string? FilePath { get; set; }
        public DateTime TimeStamp { get; set; }
        public int AppUserId { get; set; }
        public virtual AppUser? User { get; set; }
        public int TaskId { get; set; }
        public virtual Assignment? Assignment { get; set; }
    }
}

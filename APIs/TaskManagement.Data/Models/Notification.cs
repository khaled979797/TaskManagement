namespace TaskManagement.Data.Models
{
    public class Notification
    {
        public int Id { get; set; }
        public string? Message { get; set; }
        public DateTime TimeStamp { get; set; } = DateTime.Now;
        public bool IsRead { get; set; } = false;
        public int UserId { get; set; }
        public User? User { get; set; }
    }
}

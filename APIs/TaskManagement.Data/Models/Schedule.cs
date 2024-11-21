namespace TaskManagement.Data.Models
{
    public class Schedule
    {
        public int Id { get; set; }
        public string? Message { get; set; }
        public DateTime NotifyDate { get; set; }
        public int JobId { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
    }
}

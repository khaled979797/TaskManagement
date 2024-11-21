namespace TaskManagement.Data.Responses.Notifications.Queries
{
    public class GetNotificationsResponse
    {
        public int Id { get; set; }
        public string? Message { get; set; }
        public DateTime TimeStamp { get; set; }
        public bool IsRead { get; set; }
    }
}

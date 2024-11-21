namespace TaskManagement.Data.Responses.Schedules.Queries
{
    public class GetSchedulesResponse
    {
        public int Id { get; set; }
        public string? Message { get; set; }
        public DateTime NotifyDate { get; set; }
        public int JobId { get; set; }
        public string? UserName { get; set; }
    }
}

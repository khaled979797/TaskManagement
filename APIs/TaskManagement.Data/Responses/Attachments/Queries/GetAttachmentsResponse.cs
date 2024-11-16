namespace TaskManagement.Data.Responses.Attachments.Queries
{
    public class GetAttachmentsResponse
    {
        public int Id { get; set; }
        public string? FilePath { get; set; }
        public DateTime TimeStamp { get; set; }
        public string? UserName { get; set; }
    }
}

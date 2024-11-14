namespace TaskManagement.Data.Responses.Comments.Queries
{
    public class GetCommentsResponse
    {
        public int Id { get; set; }
        public string? Content { get; set; }
        public DateTime TimeStamp { get; set; }
        public string? UserName { get; set; }
    }
}

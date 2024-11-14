namespace TaskManagement.Data.Responses.Assignments.Queries
{
    public class AssignmentComment
    {
        public int Id { get; set; }
        public string? Content { get; set; }
        public DateTime TimeStamp { get; set; }
        public string? CommentedByUser { get; set; }
    }
}
namespace TaskManagement.Data.Responses.Assignments.Queries
{
    public class AssignmentAttachment
    {
        public int Id { get; set; }
        public string? FilePath { get; set; }
        public DateTime TimeStamp { get; set; }
        public string? AddedByUser { get; set; }
    }
}
namespace TaskManagement.Data.Responses.Users.Queries
{
    public class GetUsersResponse
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
    }
}

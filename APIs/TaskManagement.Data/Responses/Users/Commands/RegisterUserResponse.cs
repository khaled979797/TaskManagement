namespace TaskManagement.Data.Responses.Users.Commands
{
    public class RegisterUserResponse
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? Token { get; set; }
    }
}

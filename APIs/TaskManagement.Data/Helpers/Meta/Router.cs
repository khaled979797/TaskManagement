namespace TaskManagement.Data.Helpers.Meta
{
    public static class Router
    {
        public const string SingleRoute = "/{id}";
        public const string Username = "/{username}";
        public const string root = "Api";
        public const string version = "V1";
        public const string Rule = root + "/" + version + "/";

        public static class UserRouting
        {
            public const string Prefix = Rule + "User";
            public const string Register = Prefix + "/Register";
            public const string Login = Prefix + "/Login";
            public const string GetAllUsers = Prefix + "/GetAllUsers";
            public const string GetUserById = Prefix + "/GetUserById" + SingleRoute;
            public const string GetUserByUsername = Prefix + "/GetUserByUsername" + Username;
            public const string EditUser = Prefix + "/EditUser";
            public const string DeleteUser = Prefix + "/DeleteUser" + Username;
        }
    }
}

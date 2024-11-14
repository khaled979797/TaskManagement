namespace TaskManagement.Data.Helpers.Meta
{
    public static class Router
    {
        public const string SingleRoute = "/{id}";
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
            public const string EditUser = Prefix + "/EditUser";
            public const string DeleteUserById = Prefix + "/DeleteUserById" + SingleRoute;
        }

        public static class ProjectRouting
        {
            public const string Prefix = Rule + "Project";
            public const string AddProject = Prefix + "/AddProject";
            public const string GetAllProjects = Prefix + "/GetAllProjects";
            public const string GetProjectById = Prefix + "/GetProjectById" + SingleRoute;
            public const string EditProject = Prefix + "/EditProject";
            public const string DeleteProjectById = Prefix + "/DeleteProjectById" + SingleRoute;
        }

        public static class AssignmentRouting
        {
            public const string Prefix = Rule + "Assignment";
            public const string AddAssignment = Prefix + "/AddAssignment";
            public const string GetAllAssignments = Prefix + "/GetAllAssignments";
            public const string GetAssignmentById = Prefix + "/GetAssignmentById" + SingleRoute;
            public const string EditAssignment = Prefix + "/EditAssignment";
            public const string DeleteAssignmentById = Prefix + "/DeleteAssignmentById" + SingleRoute;
        }

        public static class CommentRouting
        {
            public const string Prefix = Rule + "Comment";
            public const string AddComment = Prefix + "/AddComment";
            public const string GetAllComments = Prefix + "/GetAllComments" + "/{assignmentId}";
            public const string GetCommentById = Prefix + "/GetCommentById" + SingleRoute;
            public const string EditComment = Prefix + "/EditComment";
            public const string DeleteCommentById = Prefix + "/DeleteCommentById" + SingleRoute;
        }

        public static class AttachmentRouting
        {
            public const string Prefix = Rule + "Attachment";
            public const string AddAttachment = Prefix + "/AddAttachment";
            public const string GetAllAttachments = Prefix + "/GetAllAttachments";
            public const string GetAttachmentById = Prefix + "/GetAttachmentById" + SingleRoute;
            public const string EditAttachment = Prefix + "/EditAttachment";
            public const string DeleteAttachmentById = Prefix + "/DeleteAttachmentById" + SingleRoute;
        }
    }
}

namespace TaskManagement.Data.Helpers.Meta
{
    public static class Router
    {
        public const string SingleRoute = "/{id}";
        public const string UserId = "/{userId}";
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
            public const string GetAllAssignmentsbyUser = Prefix + "/GetAllAssignmentsbyUser" + SingleRoute;
            public const string GetAssignmentById = Prefix + "/GetAssignmentById" + SingleRoute;
            public const string EditAssignment = Prefix + "/EditAssignment";
            public const string DeleteAssignmentById = Prefix + "/DeleteAssignmentById" + SingleRoute;
            public const string MarkAssignmentCompleted = Prefix + "/MarkAssignmentCompleted" + SingleRoute;
            public const string MarkAssignmentUncompleted = Prefix + "/MarkAssignmentUncompleted" + SingleRoute;
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
            public const string GetAllAttachments = Prefix + "/GetAllAttachments" + "/{assignmentId}";
            public const string GetAttachmentById = Prefix + "/GetAttachmentById" + SingleRoute;
            public const string DeleteAttachmentById = Prefix + "/DeleteAttachmentById" + SingleRoute;
        }

        public static class NotificationRouting
        {
            public const string Prefix = Rule + "Notification";
            public const string AddNotification = Prefix + "/AddNotification";
            public const string GetAllNotifications = Prefix + "/GetAllNotifications" + UserId;
            public const string GetNotificationById = Prefix + "/GetNotificationById" + SingleRoute;
            public const string DeleteAllNotifications = Prefix + "/DeleteAllNotifications" + UserId;
            public const string DeleteNotificationById = Prefix + "/DeleteNotificationById" + SingleRoute;
            public const string ReadAllNotifications = Prefix + "/ReadAllNotifications" + UserId;
            public const string ReadNotificationById = Prefix + "/ReadNotificationById" + SingleRoute;
            public const string UnreadAllNotifications = Prefix + "/UnreadAllNotifications" + UserId;
            public const string UnreadNotificationById = Prefix + "/UnreadNotificationById" + SingleRoute;
        }

        public static class ScheduleRouting
        {
            public const string Prefix = Rule + "Schedule";
            public const string AddSchedule = Prefix + "/AddSchedule";
            public const string EditSchedule = Prefix + "/EditSchedule";
            public const string DeleteScheduleById = Prefix + "/DeleteScheduleById" + SingleRoute;
            public const string GetAllSchedules = Prefix + "/GetAllSchedules";
            public const string GetAllSchedulesForUser = Prefix + "/GetAllSchedulesForUser" + UserId;
            public const string GetScheduleById = Prefix + "/GetScheduleById" + SingleRoute;
        }
    }
}

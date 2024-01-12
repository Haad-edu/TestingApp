using TestingApp.Domain.Entities.Users;

namespace TestingApp.Helpers
{
    public class CustomRoles
    {
        public const string USER = "User";
        public const string ADMIN = "Admin";
        public const string TEACHER = "Teacher";

        public const string USER_ROLE = USER + "," + ADMIN_ROLE;
        public const string ADMIN_ROLE = ADMIN;
        public const string ALL_ROLES = ADMIN + "," + TEACHER + "," + USER;
        public const string TEACHER_ROLE = TEACHER + "," + ADMIN;
    }
}

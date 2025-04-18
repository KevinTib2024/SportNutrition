using System.ComponentModel;

namespace SportNutrition.Model
{
    public class UserType
    {
        public int userTypeId { get; set; }

        public required string userType { get; set; }

        [DefaultValue(false)]
        public bool IsDeleted { get; set; } = false;

        public List<PermissionXUserType> permissionsXUserType { get; set; }
        public List<User> users { get; set; }
    }
}

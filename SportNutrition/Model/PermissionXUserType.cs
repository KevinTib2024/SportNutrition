using System.ComponentModel;

namespace SportNutrition.Model
{
    public class PermissionXUserType
    {
        public int permissionXUserTypeId { get; set; }

        public virtual required int userType_Id { get; set; }
        public virtual UserType userType { get; set; }


        public virtual required int permissions_Id { get; set; }
        public virtual Permissions permissions { get; set; }



        [DefaultValue(false)]
        public bool IsDeleted { get; set; } = false;

    }
}

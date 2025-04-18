using SportNutrition.DTO.Permissions;
using SportNutrition.DTO.UserType;

namespace SportNutrition.DTO.PermissionsXUserType
{
    public interface IupdatePermissionsXUserTypeRequest
    {
        int permissionXUserTypeId { get; set; }

        int userType_Id { get; set; }
        int permissions_Id { get; set; }

        //IGetUserTypeRequest? userType { get; set; }
        //IGetPermissionsRequestcs? permissions { get; set; }
    }
    public class updatePermissionsXUserTypeRequest: IupdatePermissionsXUserTypeRequest
    {
        public int permissionXUserTypeId { get; set; }

        public virtual required int userType_Id { get; set; }
        public virtual required int permissions_Id { get; set; }

        //public IGetUserTypeRequest? userType { get; set; }
        //public IGetPermissionsRequestcs? permissions { get; set; }
    }
}

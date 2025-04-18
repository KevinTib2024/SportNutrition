using SportNutrition.Model;

namespace SportNutrition.DTO.PermissionsXUserType
{
    public interface ICreatePermissionsXUserTypeRequest
    {
        int userType_Id { get; set; }
        int permissions_Id { get; set; }
    }
    public class CreatePermissionsXUserTypeRequest : ICreatePermissionsXUserTypeRequest
    {
        public  required int userType_Id { get; set; }
        public  required int permissions_Id { get; set; }

    }
}

namespace SportNutrition.DTO.UserType
{
    public interface IGetUserTypeRequest
    {
        int userTypeId { get; set; }
        string? userType { get; set; }
    }

    public class GetUserTypeRequest: IGetUserTypeRequest
    {
        public int userTypeId { get; set; }
        public string? userType { get; set; }
    }
}

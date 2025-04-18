namespace SportNutrition.DTO.UserType
{
    interface IUpdateUserTypeRequest
    {
        int userTypeId { get; set; }
        string? userType { get; set; }
    }
    public class UpdateUserTypeRequest: IUpdateUserTypeRequest
    {
        public int userTypeId { get; set; }
        public string? userType { get; set; }
    }
}

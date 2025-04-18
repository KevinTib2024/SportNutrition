namespace SportNutrition.DTO.UserType
{
    public interface ICreateUserTypeRequest
    {
        string? userType { get; set; }
    }

    public class CreateUserTypeRequest : ICreateUserTypeRequest
    {
        public string? userType { get; set; }
    }
}

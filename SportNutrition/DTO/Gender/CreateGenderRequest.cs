namespace SportNutrition.DTO.Gender
{
    public interface ICreateGenderRequest
    {
        string? gender { get; set; }
    }

    public class CreateGenderRequest
    {
        public string? gender { get; set; }
    }
}

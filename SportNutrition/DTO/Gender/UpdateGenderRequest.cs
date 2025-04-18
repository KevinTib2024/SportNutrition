namespace SportNutrition.DTO.Gender
{
    public interface IUpdateGenderRequest
    {
        int genderId { get; set; }
        string? gender { get; set; }
    }

    public class UpdateGenderRequest
    {
        public int genderId { get; set; }
        public string? gender { get; set; }
    }
}

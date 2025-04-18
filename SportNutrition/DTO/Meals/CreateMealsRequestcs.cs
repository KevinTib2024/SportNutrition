namespace SportNutrition.DTO.Meals
{
    public interface ICreateMealsRequestcs
    {
        string name { get; set; }
        string description { get; set; }
        string calories { get; set; }
        string protein { get; set; }
        string carbs { get; set; }
        string flat { get; set; }
    }
    public class CreateMealsRequestcs : ICreateMealsRequestcs
    {
        public required string name { get; set; }
        public required string description { get; set; }
        public required string calories { get; set; }
        public required string protein { get; set; }
        public required string carbs { get; set; }
        public required string flat { get; set; }
    }
}

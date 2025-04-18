namespace SportNutrition.DTO.NutritionPlans
{
    public interface ICreateNutritionPlansRequest
    {
        string? name { get; set; }
        string? description { get; set; }
        string? goal { get; set; }
        float dalyCalories { get; set; }
    }
    public class CreateNutritionPlansRequest: ICreateNutritionPlansRequest
    {
        public string? name { get; set; }
        public string? description { get; set; }
        public string? goal { get; set; }
        public float dalyCalories { get; set; }
    }
}

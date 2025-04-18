namespace SportNutrition.DTO.NutritionPlans
{
    public interface IUpdateNutritionPlansRequest
    {
        int nutritionPlansId { get; set; }

        string? name { get; set; }
        string? description { get; set; }
        string? goal { get; set; }
        float? dalyCalories { get; set; }
    }
    public class UpdateNutritionPlansRequest: IUpdateNutritionPlansRequest
    {
        public int nutritionPlansId { get; set; }

        public string? name { get; set; }
        public string? description { get; set; }
        public string? goal { get; set; }
        public float? dalyCalories { get; set; }
    }
}

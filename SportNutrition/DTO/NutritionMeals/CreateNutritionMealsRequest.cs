namespace SportNutrition.DTO.NutritionMeals
{
    public interface ICreateNutritionMealsRequest
    {
        int nutritionPlans_Id { get; set; }
        int meals_Id { get; set; }
        string? mealType { get; set; }
    }

    public class CreateNutritionMealsRequest : ICreateNutritionMealsRequest
    {
        public int nutritionPlans_Id { get; set; }
        public int meals_Id { get; set; }
        public string? mealType { get; set; }
    }
}

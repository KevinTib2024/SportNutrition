using SportNutrition.DTO.Meals;
using SportNutrition.DTO.NutritionPlans;

namespace SportNutrition.DTO.NutritionMeals
{
    public interface IUpdateNutritionMealsRequest
    {
         int nutritionMealsId { get; set; }

         int? nutritionPlans_Id { get; set; }
         int? meals_Id { get; set; }
         string? mealType { get; set; }

         //IGetNutritionPlansRequest? nutritionPlans { get; set; }
         //IGetMealsRequest? meals { get; set; }
    }

    public class UpdateNutritionMealsRequest : IUpdateNutritionMealsRequest
    {
        public int nutritionMealsId { get; set; }

        public int? nutritionPlans_Id { get; set; }
        public int? meals_Id { get; set; }
        public string? mealType { get; set; }

        //public IGetNutritionPlansRequest? nutritionPlans { get; set; }
        //public IGetMealsRequest? meals { get; set; }
    }
}

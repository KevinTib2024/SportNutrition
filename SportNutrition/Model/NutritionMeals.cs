using System.ComponentModel;

namespace SportNutrition.Model
{
    public class NutritionMeals
    {
        public int nutritionMealsId { get; set; }

        public virtual NutritionPlans nutritionPlans { get; set; }
        public virtual required int nutritionPlans_Id { get; set; }

        public virtual Meals meals { get; set; }
        public virtual required int meals_Id { get; set; }

        public required string mealType { get; set; }

        [DefaultValue(false)]
        public bool IsDeleted { get; set; } = false;
    }
}

using System.ComponentModel;

namespace SportNutrition.Model
{
    public class Meals
    {
        public int  mealsId {get; set; }

        public required string name { get; set; }
        public required string description { get; set; }
        public required string calories { get; set; }
        public required string protein { get; set; }
        public required string carbs { get; set; }
        public required string flat  { get; set; }

        [DefaultValue(false)]
        public bool IsDeleted { get; set; } = false;


        public List<NutritionMeals> nutritionMeals { get; set; }
    }
}

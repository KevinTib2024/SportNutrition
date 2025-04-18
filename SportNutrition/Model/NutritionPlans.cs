using System.ComponentModel;

namespace SportNutrition.Model
{
    public class NutritionPlans
    {
        public int nutritionPlansId { get; set; }

        public required string name { get; set; }
        public required string description { get; set; }
        public required string goal { get; set; }
        public required float dalyCalories { get; set; }

        [DefaultValue(false)]
        public bool IsDeleted { get; set; } = false;


        public List<User> users { get; set; }
        public List<NutritionMeals> nutritionMeals { get; set; }
    }
}

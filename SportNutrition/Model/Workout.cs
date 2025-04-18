using System.ComponentModel;

namespace SportNutrition.Model
{
    public class Workout
    {
        public int workoutId { get; set; }

        public required string name { get; set; }
        public required string description { get; set; }
        public required string difficultyLevel { get; set; }
        public required string duration { get; set; }
        public required string goal { get; set; }

        [DefaultValue(false)]
        public bool IsDeleted { get; set; } = false;


        public List<User> users { get; set; }
        public List<WorkoutExercises> workoutExercises { get; set; }
    }
}

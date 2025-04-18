using System.ComponentModel;
using System.Globalization;

namespace SportNutrition.Model
{
    public class Exercises
    {
        public int exercisesId { get; set; }

        public required string name { get; set; }
        public required string description { get; set; }
        public required string muscleGroup { get; set; }


        [DefaultValue(false)]
        public bool IsDeleted { get; set; } = false;

        public List<WorkoutExercises> workoutExercises { get; set; }
    }
}

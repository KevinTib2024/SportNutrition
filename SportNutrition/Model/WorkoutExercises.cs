using System.ComponentModel;

namespace SportNutrition.Model
{
    public class WorkoutExercises
    {
        public int workoutExercisesId { get; set; }

        public virtual Workout workout { get; set; }
        public virtual required int workout_Id { get; set; }

        public virtual Exercises exercises { get; set; }
        public virtual required int exercises_Id { get; set; }

        public required int sets { get; set; }
        public required int reps { get; set; }
        public required int restSeconds { get; set; }

        [DefaultValue(false)]
        public bool IsDeleted { get; set; } = false;
    }
}

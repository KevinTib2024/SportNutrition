using SportNutrition.DTO.Exercises;
using SportNutrition.DTO.Workout;

namespace SportNutrition.DTO.WorkoutExercises
{
    public interface IUpdateWorkoutExercisesRequest
    {
        int workoutExercisesId { get; set; }

        int workout_Id { get; set; }
        int exercises_Id { get; set; }

        int? sets { get; set; }
        int? reps { get; set; }
        int? restSeconds { get; set; }

        //IGetWorkoutRequest? workout { get; set; }
        //IGetExercisesRequest? exercises { get; set; }
    }

    public class UpdateWorkoutExercisesRequest: IUpdateWorkoutExercisesRequest
    {
        public int workoutExercisesId { get; set; }

        public int workout_Id { get; set; }
        public int exercises_Id { get; set; }

        public int? sets { get; set; }
        public int? reps { get; set; }
        public int? restSeconds { get; set; }

        //public IGetWorkoutRequest? workout { get; set; }
        //public IGetExercisesRequest? exercises { get; set; }
    }
}

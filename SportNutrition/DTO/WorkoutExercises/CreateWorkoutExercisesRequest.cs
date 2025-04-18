namespace SportNutrition.DTO.WorkoutExercises
{
    public interface ICreateWorkoutExercisesRequest
    {
        int workout_Id { get; set; }
        int exercises_Id { get; set; }

        int sets { get; set; }
        int reps { get; set; }
        int restSeconds { get; set; }
    }

    public class CreateWorkoutExercisesRequest : ICreateWorkoutExercisesRequest
    {
        public int workout_Id { get; set; }
        public int exercises_Id { get; set; }

        public int sets { get; set; }
        public int reps { get; set; }
        public int restSeconds { get; set; }
    }
}

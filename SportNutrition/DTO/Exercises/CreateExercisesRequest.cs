namespace SportNutrition.DTO.Exercises
{
    public interface ICreateExercisesRequest
    {

        string name { get; set; }
        string description { get; set; }
        string muscleGroup { get; set; }
    }
    public class CreateExercisesRequest: ICreateExercisesRequest
    {

        public required string name { get; set; }
        public required string description { get; set; }
        public required string muscleGroup { get; set; }
    }
}

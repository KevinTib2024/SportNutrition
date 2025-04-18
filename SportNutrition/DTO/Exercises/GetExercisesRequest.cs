namespace SportNutrition.DTO.Exercises
{
    public interface IGetExercisesRequest
    {
        int exercisesId { get; set; }

        string name { get; set; }
        string description { get; set; }
        string muscleGroup { get; set; }
    }
    public class GetExercisesRequest : IGetExercisesRequest
    {
        public int exercisesId { get; set; }

        public required string name { get; set; }
        public required string description { get; set; }
        public required string muscleGroup { get; set; }
    }
}

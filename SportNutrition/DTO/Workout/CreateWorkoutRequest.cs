namespace SportNutrition.DTO.Workout
{
    public interface ICreateWorkoutRequest
    {
        string name { get; set; }
        string? description { get; set; }
        string difficultyLevel { get; set; }
        string duration { get; set; }
        string goal { get; set; }
    }

    public class CreateWorkoutRequest : ICreateWorkoutRequest
    {
        public required string name { get; set; }
        public string? description { get; set; }
        public required string difficultyLevel { get; set; }
        public required string duration { get; set; }
        public required string goal { get; set; }
    }
}

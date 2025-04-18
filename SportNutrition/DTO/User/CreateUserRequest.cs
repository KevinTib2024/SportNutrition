namespace SportNutrition.DTO.User
{
    public interface ICreateUserRequest
    {
        int gender_Id { get; set; }
        int identificationType_Id { get; set; }
        int user_Type_Id { get; set; }
        int workout_Id { get; set; }
        int nutritionPlans_Id { get; set; }

        string? names { get; set; }
        string? lastNames { get; set; }
        string? identificationNumber { get; set; }
        string? birthDate { get; set; }
        string? email { get; set; }
        string? password { get; set; }
        string? contact { get; set; }
        float height { get; set; }
        float weight { get; set; }


    }

    public class CreateUserRequest : ICreateUserRequest
    {
        public int gender_Id { get; set; }
        public int identificationType_Id { get; set; }
        public int user_Type_Id { get; set; }
        public int workout_Id { get; set; }
        public int nutritionPlans_Id { get; set; }

        public string? names { get; set; }
        public string? lastNames { get; set; }
        public string? identificationNumber { get; set; }
        public string? birthDate { get; set; }
        public string? email { get; set; }
        public string? password { get; set; }
        public string? contact { get; set; }
        public float height { get; set; }
        public float weight { get; set; }
    }
}

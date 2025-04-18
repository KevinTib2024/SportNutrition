using SportNutrition.DTO.Gender;
using SportNutrition.DTO.IdentificationType;
using SportNutrition.DTO.UserType;
using SportNutrition.DTO.Workout;
using SportNutrition.DTO.NutritionPlans;

namespace SportNutrition.DTO.User
{
    public interface IGetUserRequets
    {
        int userId { get; set; }
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
        string? contact { get; set; }

        float height { get; set; }
        float weight { get; set; }

        /*IGetGenderRequest? gender { get; set; }
        IGetIdentificationTypeRequest? identificationType { get; set; }
        IGetUserTypeRequest? userType { get; set; }
        IGetWorkoutRequest? workout { get; set; }
        IGetNutritionPlansRequest? nutritionPlans { get; set; }*/
    }

    public class GetUserRequets : IGetUserRequets
    {
        public int userId { get; set; }
        public int gender_Id { get; set; }
        public int identificationType_Id { get; set; }
        public int user_Type_Id { get; set; }
        public int workout_Id { get; set; }
        public int nutritionPlans_Id { get; set; }

        public string? identificationNumber { get; set; }
        public string? birthDate { get; set; }
        public string? email { get; set; }
        public string? contact { get; set; }
        public string? lastNames { get; set; }
        public string? names { get; set; }

        public float height { get; set; }
        public float weight { get; set; }

        /*
        public IGetGenderRequest? gender { set; get; }
        public IGetIdentificationTypeRequest? identificationType { get; set; }
        public IGetUserTypeRequest? userType { get; set; }
        public IGetWorkoutRequest? workout { get; set; }
        public IGetNutritionPlansRequest? nutritionPlans { get; set; }*/
    }
}

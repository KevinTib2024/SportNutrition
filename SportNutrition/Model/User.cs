using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace SportNutrition.Model
{
    public class User
    {
        public int userId { get; set; }

        public virtual UserType user_Type { get; set; }
        public virtual required int user_Type_Id { get; set; }


        public virtual IdentificationType identificationType { get; set; }
        public virtual required int identificationType_Id { get; set; }

        public required string identificationNumber { get; set; }
        public required string names { get; set; }
        public required string lastNames { get; set; }
        public required string birthDate { get; set; }
        public required string contact { get; set; }

        public virtual Gender gender { get; set; }
        public virtual required int gender_Id { get; set; }

        public required float height { get; set; }
        public required float weight { get; set; }


        public virtual Workout workout { get; set; }
        public virtual required int workout_Id { get; set; }


        public virtual NutritionPlans nutritionPlans { get; set; }
        [ForeignKey(nameof(nutritionPlans))]
        public virtual required int nutritionPlans_Id { get; set; }


        public required string email { get; set; }

        public required string password { get; set; }


        [DefaultValue(false)]
        public bool IsDeleted { get; set; } = false;
    }
}

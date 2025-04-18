using System.ComponentModel;

namespace SportNutrition.Model
{
    public class Gender
    {
        public int genderId { get; set; }

        public required string gender { get; set; }

        [DefaultValue(false)]
        public bool IsDeleted { get; set; } = false;

        public List<User> users { get; set; }
    }
}

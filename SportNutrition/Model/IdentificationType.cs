using System.ComponentModel;

namespace SportNutrition.Model
{
    public class IdentificationType
    {
        public int IdentificationTypeId { get; set; }

        public required string Identification_Type { get; set; }


        [DefaultValue(false)]
        public bool IsDeleted { get; set; } = false;

        public List<User> users { get; set; }
    }
}

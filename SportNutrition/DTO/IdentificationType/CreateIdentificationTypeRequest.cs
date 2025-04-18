namespace SportNutrition.DTO.IdentificationType
{
    public interface ICreateIdentificationTypeRequest
    {
        string? Identification_Type { get; set; }
    }

    public class CreateIdentificationTypeRequest : ICreateIdentificationTypeRequest
    {
        public string? Identification_Type { get; set; }
    }
}

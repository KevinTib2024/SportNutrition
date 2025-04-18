namespace SportNutrition.DTO.IdentificationType
{
    public interface IUpdateIdentificationTypeRequest
    {
        int IdentificationTypeId { get; set; }
        string? Identification_Type { get; set; }
    }

    public class UpdateIdentificationTypeRequest : IUpdateIdentificationTypeRequest
    {
        public int IdentificationTypeId { get; set; }
        public string? Identification_Type { get; set; }
    }
}

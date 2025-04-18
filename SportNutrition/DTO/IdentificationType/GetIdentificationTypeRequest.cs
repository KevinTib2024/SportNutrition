namespace SportNutrition.DTO.IdentificationType
{
    public interface IGetIdentificationTypeRequest
    {
        int IdentificationTypeId { get; set; }
        string? Identification_Type { get; set; }
    }
    public class GetIdentificationTypeRequest : IGetIdentificationTypeRequest
    {
        public int IdentificationTypeId { get; set; }
        public string? Identification_Type { get; set; }
    }
}

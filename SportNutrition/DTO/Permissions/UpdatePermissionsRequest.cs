namespace SportNutrition.DTO.Permissions
{
    public interface IUpdatePermissionsRequest
    {
        int permissionsId { get; set; }
        string permission { get; set; }
    }
    public class UpdatePermissionsRequest: IUpdatePermissionsRequest
    {
        public int permissionsId { get; set; }
        public required string permission { get; set; }
    }
}

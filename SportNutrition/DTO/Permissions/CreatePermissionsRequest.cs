namespace SportNutrition.DTO.Permissions
{
    public interface ICreatePermissionsRequest
    {
        string permission { get; set; }
    }

    public class CreatePermissionsRequest: ICreatePermissionsRequest
    {
        public required string permission { get; set; }
    }
}

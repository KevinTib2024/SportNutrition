namespace SportNutrition.DTO.Permissions
{
    public interface IGetPermissionsRequestcs
    {
        int permissionsId { get; set; }
        string permission { get; set; }
    }

    public class GetPermissionsRequestcs: IGetPermissionsRequestcs
    {
        public int permissionsId { get; set; }
        public required string permission { get; set; }
    }
}

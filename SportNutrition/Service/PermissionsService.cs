using SportNutrition.DTO.Permissions;
using SportNutrition.Model;
using SportNutrition.Repository;

namespace SportNutrition.Service
{
    public interface IPermissionsService
    {
        Task<IEnumerable<GetPermissionsRequestcs>> GetAllPermissionsAsync();
        Task<Permissions> GetPermissionsByIdAsync(int id);
        Task CreatePermissionsAsync(CreatePermissionsRequest permissions);
        Task UpdatePermissionsAsync(UpdatePermissionsRequest permissions);
        Task SoftDeletePermissionsAsync(int id);
    }

    public class PermissionsService: IPermissionsService
    {
        private readonly IPermissionsRepository _permissionsRepository;

        public PermissionsService(IPermissionsRepository permissionsRepository)
        {
            _permissionsRepository = permissionsRepository;
        }

        public async Task CreatePermissionsAsync(CreatePermissionsRequest permissions)
        {
            await _permissionsRepository.CreatePermissionsAsync(permissions);
        }

        public async Task<IEnumerable<GetPermissionsRequestcs>> GetAllPermissionsAsync()
        {
            return await _permissionsRepository.GetAllPermissionsAsync();
        }

        public async Task<Permissions> GetPermissionsByIdAsync(int id)
        {
            return await _permissionsRepository.GetPermissionsByIdAsync(id);
        }

        public async Task SoftDeletePermissionsAsync(int id)
        {
            await _permissionsRepository.SoftDeletePermissionsAsync(id);
        }

        public async Task UpdatePermissionsAsync(UpdatePermissionsRequest permissions)
        {
            await _permissionsRepository.UpdatePermissionsAsync(permissions);
        }
    }
}

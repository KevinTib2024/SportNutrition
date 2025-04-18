using SportNutrition.DTO.PermissionsXUserType;
using SportNutrition.Model;
using SportNutrition.Repository;

namespace SportNutrition.Service
{
    public interface IPermissionsXUserTypeService
    {
        Task<IEnumerable<GetPermissionsXUserTypeRequest>> GetAllPermissionXUserTypeAsync();
        Task<GetPermissionsXUserTypeRequest> GetPermissionXUserTypeByIdAsync(int id);
        Task CreatePermissionXUserTypeAsync(CreatePermissionsXUserTypeRequest permissionXUserType);
        Task UpdatePermissionXUserTypeAsync(updatePermissionsXUserTypeRequest permissionXUserType);
        Task SoftDeletePermissionXUserTypeAsync(int id);
        Task<bool> HasPermissionAsync(int userType_Id, int permissions_Id);
    }

    public class PermissionsXUserTypeService : IPermissionsXUserTypeService
    {
        private readonly IPermissionsXUserTypeRepositorycs _permissionXUserTypeRepository;

        public PermissionsXUserTypeService(IPermissionsXUserTypeRepositorycs permissionXUserTypeRepository)
        {
            _permissionXUserTypeRepository = permissionXUserTypeRepository;
        }

        public async Task CreatePermissionXUserTypeAsync(CreatePermissionsXUserTypeRequest permissionXUserType)
        {
            await _permissionXUserTypeRepository.CreatePermissionXUserTypeAsync(permissionXUserType);
        }

        public async Task<IEnumerable<GetPermissionsXUserTypeRequest>> GetAllPermissionXUserTypeAsync()
        {
            return await _permissionXUserTypeRepository.GetAllPermissionXUserTypeAsync();
        }

        public async Task<GetPermissionsXUserTypeRequest> GetPermissionXUserTypeByIdAsync(int id)
        {
            return await _permissionXUserTypeRepository.GetPermissionXUserTypeByIdAsync(id);
        }

        public async Task<bool> HasPermissionAsync(int userType_Id, int permissions_Id)
        {
            try
            {
                return await _permissionXUserTypeRepository.HasPermissionAsync(userType_Id, permissions_Id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task SoftDeletePermissionXUserTypeAsync(int id)
        {
            await _permissionXUserTypeRepository.SoftDeletePermissionXUserTypeAsync(id);
        }

        public async Task UpdatePermissionXUserTypeAsync(updatePermissionsXUserTypeRequest permissionXUserType)
        {
            await _permissionXUserTypeRepository.UpdatePermissionXUserTypeAsync(permissionXUserType);
        }
    }
}

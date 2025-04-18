using Microsoft.EntityFrameworkCore;
using SportNutrition.Context;
using SportNutrition.DTO.PermissionsXUserType;
using SportNutrition.DTO.WorkoutExercises;
using SportNutrition.Model;

namespace SportNutrition.Repository
{
    public interface IPermissionsXUserTypeRepositorycs
    {
        Task<IEnumerable<GetPermissionsXUserTypeRequest>> GetAllPermissionXUserTypeAsync();
        Task<GetPermissionsXUserTypeRequest> GetPermissionXUserTypeByIdAsync(int id);
        Task CreatePermissionXUserTypeAsync(CreatePermissionsXUserTypeRequest permissionXUserType);
        Task UpdatePermissionXUserTypeAsync(updatePermissionsXUserTypeRequest permissionXUserType);
        Task SoftDeletePermissionXUserTypeAsync(int id);
        Task<bool> HasPermissionAsync(int userType_Id, int permissionsId);
    }
    public class PermissionsXUserTypeRepositorycs : IPermissionsXUserTypeRepositorycs
    {
        private readonly SportNutritionDbContext _context;

        public PermissionsXUserTypeRepositorycs(SportNutritionDbContext context)
        {
            _context = context;
        }

        public async Task CreatePermissionXUserTypeAsync(CreatePermissionsXUserTypeRequest permissionXUserType)
        {
            if (permissionXUserType == null)
                throw new ArgumentNullException(nameof(permissionXUserType));
            var _permissionsXUserType = new PermissionXUserType
            {
                userType_Id = permissionXUserType.userType_Id,
                permissions_Id = permissionXUserType.permissions_Id

            };


            // Agregar el objeto al contexto
            _context.permissionXUserType.Add(_permissionsXUserType);

            // Guardar cambios en la base de datos
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<GetPermissionsXUserTypeRequest>> GetAllPermissionXUserTypeAsync()
        {
            return await _context.permissionXUserType
             .Where(s => !s.IsDeleted)
             .Select(s => new GetPermissionsXUserTypeRequest
             {
                 permissionXUserTypeId = s.permissionXUserTypeId,
                 userType_Id = s.userType_Id,
                 permissions_Id = s.permissions_Id
             })
             .ToListAsync();
        }

        public async Task<GetPermissionsXUserTypeRequest> GetPermissionXUserTypeByIdAsync(int id)
        {
            return await _context.permissionXUserType
            .Where(s => s.permissionXUserTypeId == id && !s.IsDeleted)
            .Select(s => new GetPermissionsXUserTypeRequest
            {
                permissionXUserTypeId = s.permissionXUserTypeId,
                userType_Id = s.userType_Id,
                permissions_Id = s.permissions_Id
            })
            .FirstOrDefaultAsync();
        }

        public async Task<bool> HasPermissionAsync(int userType_Id, int permissionsId)
        {
            var permission = await _context.permissionXUserType
            .Where(p => p.userType_Id == userType_Id && p.permissions_Id == permissionsId && !p.IsDeleted)
            .FirstOrDefaultAsync();

            return permission != null ? true : false;
        }

        public async Task SoftDeletePermissionXUserTypeAsync(int id)
        {
            var permissionXUserType = await _context.permissionXUserType.FindAsync(id);
            if (permissionXUserType != null)
            {
                permissionXUserType.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdatePermissionXUserTypeAsync(updatePermissionsXUserTypeRequest permissionXUserType)
        {
            if (permissionXUserType == null)
                throw new ArgumentNullException(nameof(permissionXUserType));

            var existingPermissionXUserType = await _context.permissionXUserType.FindAsync(permissionXUserType.permissionXUserTypeId);
            if (existingPermissionXUserType == null)
                throw new ArgumentException($"permissionXUserType with ID {permissionXUserType.permissionXUserTypeId} not found");

            // Actualizar las propiedades del objeto existente
            existingPermissionXUserType.userType_Id = permissionXUserType.userType_Id;
            existingPermissionXUserType.permissions_Id = permissionXUserType.permissions_Id;

            await _context.SaveChangesAsync();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using SportNutrition.Context;
using SportNutrition.DTO.Permissions;
using SportNutrition.Model;

namespace SportNutrition.Repository
{
    public interface IPermissionsRepository
    {
        Task<IEnumerable<GetPermissionsRequestcs>> GetAllPermissionsAsync();
        Task<Permissions> GetPermissionsByIdAsync(int id);
        Task CreatePermissionsAsync(CreatePermissionsRequest permissions);
        Task UpdatePermissionsAsync(UpdatePermissionsRequest permissions);
        Task SoftDeletePermissionsAsync(int id);
    }

    public class PermissionsRepository : IPermissionsRepository
    {
        private readonly SportNutritionDbContext _context;

        public PermissionsRepository(SportNutritionDbContext context)
        {
            _context = context;
        }

        public async Task CreatePermissionsAsync(CreatePermissionsRequest permissions)
        {
            if (permissions == null)
                throw new ArgumentNullException(nameof(permissions));
            var _newpermissions = new Permissions
            {
                permission = permissions.permission,

            };


            // Agregar el objeto al contexto
            _context.permissions.Add(_newpermissions);

            // Guardar cambios en la base de datos
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<GetPermissionsRequestcs>> GetAllPermissionsAsync()
        {
            return await _context.permissions
            .Where(s => !s.IsDeleted)
            .Select(s => new GetPermissionsRequestcs { permissionsId = s.permissionsId, permission = s.permission })
            .ToListAsync();
        }

        public async Task<Permissions> GetPermissionsByIdAsync(int id)
        {
            return await _context.permissions
            .FirstOrDefaultAsync(s => s.permissionsId == id && !s.IsDeleted);
        }

        public async Task SoftDeletePermissionsAsync(int id)
        {
            var permissions = await _context.permissions.FindAsync(id);
            if (permissions != null)
            {
                permissions.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdatePermissionsAsync(UpdatePermissionsRequest permissions)
        {
            if (permissions == null)
                throw new ArgumentNullException(nameof(permissions));

            var existingPermissions = await _context.permissions.FindAsync(permissions.permissionsId);
            if (existingPermissions == null)
                throw new ArgumentException($"permissions with ID {permissions.permissionsId} not found");

            // Actualizar las propiedades del objeto existente
            existingPermissions.permission = String.IsNullOrEmpty(permissions.permission) ? existingPermissions.permission : permissions.permission;

            await _context.SaveChangesAsync();
        }
    }
}

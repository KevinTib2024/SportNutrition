using Microsoft.EntityFrameworkCore;
using SportNutrition.Context;
using SportNutrition.DTO.UserType;
using SportNutrition.Model;

namespace SportNutrition.Repository
{
    public interface IUserTypeRepository
    {
        Task<IEnumerable<GetUserTypeRequest>> GetAllUserTypeAsync();
        Task<GetUserTypeRequest> GetUserTypeByIdAsync(int id);
        Task CreateUserTypeAsync(CreateUserTypeRequest userType);
        Task UpdateUserTypeAsync(UpdateUserTypeRequest userType);
        Task SoftDeleteUserTypeAsync(int id);
    }
    public class UserTypeRepository: IUserTypeRepository
    {
        private readonly SportNutritionDbContext _context;

        public UserTypeRepository(SportNutritionDbContext context)
        {
            _context = context;
        }

        public async Task CreateUserTypeAsync(CreateUserTypeRequest userType)
        {
            if (userType == null)
                throw new ArgumentNullException(nameof(userType));
            var _newUserType = new UserType
            {
                userType = userType.userType,
            };

            // Agregar el objeto al contexto
            _context.userType.Add(_newUserType);

            // Guardar cambios en la base de datos
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<GetUserTypeRequest>> GetAllUserTypeAsync()
        {
            return await _context.userType
            .Where(s => !s.IsDeleted)
            .Select(s => new GetUserTypeRequest { userType = s.userType, userTypeId = s.userTypeId })
            .ToListAsync();
        }

        public async Task<GetUserTypeRequest> GetUserTypeByIdAsync(int id)
        {
            return await _context.userType
            .Where(s => s.userTypeId == id && !s.IsDeleted)
            .Select(s => new GetUserTypeRequest { userTypeId = s.userTypeId, userType = s.userType }).FirstOrDefaultAsync();

        }

        public async Task SoftDeleteUserTypeAsync(int id)
        {
            var userType = await _context.userType.FindAsync(id);
            if (userType != null)
            {
                userType.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateUserTypeAsync(UpdateUserTypeRequest userType)
        {
            if (userType == null)
                throw new ArgumentNullException(nameof(userType));

            var existingUserType = await _context.userType.FindAsync(userType.userTypeId);
            if (existingUserType == null)
                throw new ArgumentException($"UserType with ID {userType.userTypeId} not found");

            // Actualizar las propiedades del objeto existente
            existingUserType.userType = String.IsNullOrEmpty(userType.userType) ? existingUserType.userType : userType.userType;

            await _context.SaveChangesAsync();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using SportNutrition.Context;
using SportNutrition.DTO.IdentificationType;
using SportNutrition.Model;

namespace SportNutrition.Repository
{
    public interface IIdentificationTypeRepository
    {
        Task<IEnumerable<GetIdentificationTypeRequest>> GetAllIdentificationTypeAsync();
        Task<GetIdentificationTypeRequest> GetIdentificationTypeByIdAsync(int id);
        Task CreateIdentificationTypeAsync(CreateIdentificationTypeRequest identificationType);
        Task UpdateIdentificationTypeAsync(UpdateIdentificationTypeRequest identificationType);
        Task SoftDeleteIdentificationTypeAsync(int id);
    }

    public class IdentificationTypeRepository : IIdentificationTypeRepository
    {
        private readonly SportNutritionDbContext _context;

        public IdentificationTypeRepository(SportNutritionDbContext context)
        {
            _context = context;
        }

        public async Task CreateIdentificationTypeAsync(CreateIdentificationTypeRequest identificationType)
        {
            if (identificationType == null)
                throw new ArgumentNullException(nameof(identificationType));
            var _newIdentificationType = new IdentificationType
            {
                Identification_Type = identificationType.Identification_Type,
            };

            // Agregar el objeto al contexto
            _context.identificationType.Add(_newIdentificationType);

            // Guardar cambios en la base de datos
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<GetIdentificationTypeRequest>> GetAllIdentificationTypeAsync()
        {
            return await _context.identificationType
           .Where(s => !s.IsDeleted)
           .Select(s => new GetIdentificationTypeRequest { Identification_Type = s.Identification_Type, IdentificationTypeId = s.IdentificationTypeId })
           .ToListAsync();
        }

        public async Task<GetIdentificationTypeRequest> GetIdentificationTypeByIdAsync(int id)
        {
            return await _context.identificationType
            .Where(s => s.IdentificationTypeId == id && !s.IsDeleted)
            .Select(s => new GetIdentificationTypeRequest { IdentificationTypeId = s.IdentificationTypeId, Identification_Type = s.Identification_Type }).FirstOrDefaultAsync();

        }

        public async Task SoftDeleteIdentificationTypeAsync(int id)
        {
            var identificationType = await _context.identificationType.FindAsync(id);
            if (identificationType != null)
            {
                identificationType.IsDeleted = true;
                await _context.SaveChangesAsync();

            }
        }

        public async Task UpdateIdentificationTypeAsync(UpdateIdentificationTypeRequest identificationType)
        {
            if (identificationType == null)
                throw new ArgumentNullException(nameof(identificationType));

            var existingIdentificationType = await _context.identificationType.FindAsync(identificationType.IdentificationTypeId);
            if (existingIdentificationType == null)
                throw new ArgumentException($"IdentificationType with ID {identificationType.IdentificationTypeId} not found");

            // Actualizar las propiedades del objeto existente
            existingIdentificationType.Identification_Type = String.IsNullOrEmpty(identificationType.Identification_Type) ? existingIdentificationType.Identification_Type : identificationType.Identification_Type;

            await _context.SaveChangesAsync();
        }
    }
}

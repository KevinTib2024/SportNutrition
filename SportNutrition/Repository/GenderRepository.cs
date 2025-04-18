using Microsoft.EntityFrameworkCore;
using SportNutrition.Context;
using SportNutrition.DTO.Gender;
using SportNutrition.Model;

namespace SportNutrition.Repository
{
    public interface IGenderRepository
    {
        Task<IEnumerable<GetGenderRequest>> GetAllGenderAsync();
        Task<GetGenderRequest> GetGenderByIdAsync(int id);
        Task CreateGenderAsync(CreateGenderRequest gender);
        Task UpdateGenderAsync(UpdateGenderRequest gender);
        Task SoftDeleteGenderAsync(int id);
    }

    public class GenderRepository : IGenderRepository
    {
        private readonly SportNutritionDbContext _context;

        public GenderRepository(SportNutritionDbContext context)
        {
            _context = context;
        }

        public async Task CreateGenderAsync(CreateGenderRequest gender)
        {
            if (gender == null)
                throw new ArgumentNullException(nameof(gender));
            var _newGender = new Gender
            {
                gender = gender.gender
            };

            // Agregar el objeto al contexto
            _context.gender.Add(_newGender);


            // Guardar cambios en la base de datos
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<GetGenderRequest>> GetAllGenderAsync()
        {
            return await _context.gender
            .Where(s => !s.IsDeleted)
            .Select(s => new GetGenderRequest { gender = s.gender, genderId = s.genderId })
             .ToListAsync();
        }

        public async Task<GetGenderRequest> GetGenderByIdAsync(int id)
        {
            return await _context.gender
                .Where(s => s.genderId == id && !s.IsDeleted)
                .Select(s => new GetGenderRequest { gender = s.gender, genderId = s.genderId }).FirstOrDefaultAsync();
        }

        public async Task SoftDeleteGenderAsync(int id)
        {
            var gender = await _context.gender.FindAsync(id);
            if (gender != null)
            {
                gender.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateGenderAsync(UpdateGenderRequest gender)
        {
            if (gender == null)
                throw new ArgumentNullException(nameof(gender));

            var existingGender = await _context.gender.FindAsync(gender.genderId);
            if (existingGender == null)
                throw new ArgumentException($"Gender with ID {gender.genderId} not found");

            // Actualizar las propiedades del objeto existente

            existingGender.gender = String.IsNullOrEmpty(gender.gender) ? existingGender.gender : gender.gender;



            await _context.SaveChangesAsync();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using SportNutrition.Context;
using SportNutrition.DTO.Exercises;
using SportNutrition.DTO.NutritionPlans;
using SportNutrition.Model;

namespace SportNutrition.Repository
{
    public interface INutritionPlansRepository
    {
        Task<IEnumerable<GetNutritionPlansRequest>> GetAllNutritionPlansAsync();
        Task<NutritionPlans> GetNutritionPlansByIdAsync(int id);
        Task CreateNutritionPlansAsync(CreateNutritionPlansRequest NutritionPlans);
        Task UpdateNutritionPlansAsync(UpdateNutritionPlansRequest NutritionPlans);
        Task SoftDeleteNutritionPlansAsync(int id);
    }
    public class NutritionPlansRepository: INutritionPlansRepository
    {
        private readonly SportNutritionDbContext _context;

        public NutritionPlansRepository(SportNutritionDbContext context)
        {
            _context = context;
        }

        public async Task CreateNutritionPlansAsync(CreateNutritionPlansRequest NutritionPlans)
        {
            if (NutritionPlans == null)
                throw new ArgumentNullException(nameof(NutritionPlans));
            var _newNutritionPlans = new NutritionPlans
            {

                name = NutritionPlans.name,
                description = NutritionPlans.description,
                goal = NutritionPlans.goal,
                dalyCalories = NutritionPlans.dalyCalories

            };


            // Agregar el objeto al contexto
            _context.nutritionPlans.Add(_newNutritionPlans);

            // Guardar cambios en la base de datos
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<GetNutritionPlansRequest>> GetAllNutritionPlansAsync()
        {
            return await _context.nutritionPlans
            .Where(s => !s.IsDeleted)
            .Select(s => new GetNutritionPlansRequest
            {
                nutritionPlansId = s.nutritionPlansId,
                name = s.name,
                description = s.description,
                goal = s.goal,
                dalyCalories = s.dalyCalories
            })
            .ToListAsync();
        }

        public async Task<NutritionPlans> GetNutritionPlansByIdAsync(int id)
        {
            return await _context.nutritionPlans
            .Where(s => s.nutritionPlansId == id && !s.IsDeleted)
            .Select(s => new NutritionPlans
            {
                nutritionPlansId = s.nutritionPlansId,
                name = s.name,
                description = s.description,
                goal = s.goal,
                dalyCalories = s.dalyCalories
            })
            .FirstOrDefaultAsync();
        }

        public async Task SoftDeleteNutritionPlansAsync(int id)
        {
            var nutritionPlans = await _context.nutritionPlans.FindAsync(id);
            if (nutritionPlans != null)
            {
                nutritionPlans.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateNutritionPlansAsync(UpdateNutritionPlansRequest NutritionPlans)
        {
            if (NutritionPlans == null)
                throw new ArgumentNullException(nameof(NutritionPlans));

            var existingNutritionPlans = await _context.nutritionPlans.FindAsync(NutritionPlans.nutritionPlansId);
            if (existingNutritionPlans == null)
                throw new ArgumentException($"NutritionPlans with ID {NutritionPlans.nutritionPlansId} not found");

            // Actualizar las propiedades del objeto existente
            existingNutritionPlans.name = String.IsNullOrEmpty(NutritionPlans.name) ? existingNutritionPlans.name : NutritionPlans.name;
            existingNutritionPlans.description = String.IsNullOrEmpty(NutritionPlans.description) ? existingNutritionPlans.description : NutritionPlans.description;
            existingNutritionPlans.goal = String.IsNullOrEmpty(NutritionPlans.goal) ? existingNutritionPlans.goal : NutritionPlans.goal;
            existingNutritionPlans.dalyCalories = NutritionPlans.dalyCalories ?? existingNutritionPlans.dalyCalories;

            await _context.SaveChangesAsync();
        }
    }
}

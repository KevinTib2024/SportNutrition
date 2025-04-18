using Microsoft.EntityFrameworkCore;
using SportNutrition.Context;
using SportNutrition.DTO.Exercises;
using SportNutrition.DTO.NutritionMeals;
using SportNutrition.Model;

namespace SportNutrition.Repository
{
    public interface INutritionMealsRepository
    {
        Task<IEnumerable<GetNutritionMealsRequest>> GetAllNutritionMealsAsync();
        Task<NutritionMeals> GetNutritionMealsByIdAsync(int id);
        Task CreateNutritionMealsAsync(CreateNutritionMealsRequest NutritionMeals);
        Task UpdateNutritionMealsAsync(UpdateNutritionMealsRequest NutritionMeals);
        Task SoftDeleteNutritionMealsAsync(int id);
    }

    public class NutritionMealsRepository: INutritionMealsRepository
    {
        private readonly SportNutritionDbContext _context;

        public NutritionMealsRepository(SportNutritionDbContext context)
        {
            _context = context;
        }

        public async Task CreateNutritionMealsAsync(CreateNutritionMealsRequest NutritionMeals)
        {
            var _nutritionPlans = await _context.nutritionPlans.FindAsync(NutritionMeals.nutritionPlans_Id);
            var _meals = await _context.meals.FindAsync(NutritionMeals.meals_Id);

            if (_nutritionPlans == null)
            {
                throw new Exception("No se encontro nutritionPlans");
            }

            if (_meals == null)
            {
                throw new Exception("No se encontro  meals");

            }

            if (NutritionMeals == null)
                throw new ArgumentNullException(nameof(NutritionMeals));
            var _newNutritionMeals = new NutritionMeals
            {
               nutritionPlans_Id = NutritionMeals.nutritionPlans_Id,
               meals_Id = NutritionMeals.meals_Id,
               mealType  = NutritionMeals.mealType

            };  


            // Agregar el objeto al contexto
            _context.nutritionMeals.Add(_newNutritionMeals);

            // Guardar cambios en la base de datos
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<GetNutritionMealsRequest>> GetAllNutritionMealsAsync()
        {
            return await _context.nutritionMeals
            .Where(s => !s.IsDeleted)
            .Select(s => new GetNutritionMealsRequest
            {
                nutritionMealsId = s.nutritionMealsId,
                nutritionPlans_Id = s.nutritionPlans_Id,
                meals_Id = s.meals_Id,
                mealType = s.mealType
            })
            .ToListAsync();
        }

        public async Task<NutritionMeals> GetNutritionMealsByIdAsync(int id)
        {
            return await _context.nutritionMeals
            .Where(s => s.nutritionMealsId == id && !s.IsDeleted)
            .Select(s => new NutritionMeals
            {
                nutritionMealsId = s.nutritionMealsId,
                nutritionPlans_Id = s.nutritionPlans_Id,
                meals_Id = s.meals_Id,
                mealType = s.mealType
            })
            .FirstOrDefaultAsync();
        }

        public async Task SoftDeleteNutritionMealsAsync(int id)
        {
            var nutritionMeals = await _context.nutritionMeals.FindAsync(id);
            if (nutritionMeals != null)
            {
                nutritionMeals.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateNutritionMealsAsync(UpdateNutritionMealsRequest NutritionMeals)
        {
            if (NutritionMeals == null)
                throw new ArgumentNullException(nameof(NutritionMeals));

            var existingNutritionMeals = await _context.nutritionMeals.FindAsync(NutritionMeals.nutritionMealsId);
            if (existingNutritionMeals == null)
                throw new ArgumentException($"NutritionMeals with ID {NutritionMeals.nutritionMealsId} not found");

            // Actualizar las propiedades del objeto existente
            existingNutritionMeals.nutritionPlans_Id = (int)(NutritionMeals.nutritionPlans_Id == null ? existingNutritionMeals.nutritionPlans_Id : NutritionMeals.nutritionPlans_Id);
            existingNutritionMeals.meals_Id = (int)(NutritionMeals.meals_Id == null ? existingNutritionMeals.meals_Id : NutritionMeals.meals_Id);
            existingNutritionMeals.mealType = String.IsNullOrEmpty(NutritionMeals.mealType) ? existingNutritionMeals.mealType : NutritionMeals.mealType;

            await _context.SaveChangesAsync();
        }
    }
}

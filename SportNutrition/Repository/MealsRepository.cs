using Microsoft.EntityFrameworkCore;
using SportNutrition.Context;
using SportNutrition.DTO.Exercises;
using SportNutrition.DTO.Meals;
using SportNutrition.DTO.WorkoutExercises;
using SportNutrition.Model;

namespace SportNutrition.Repository
{
    public interface IMealsRepository
    {
        Task<IEnumerable<GetMealsRequest>> GetMealsAsync();
        Task<Meals> GetMealsByIdAsync(int id);
        Task CreateMealsAsync(CreateMealsRequestcs Meals);
        Task UpdateMealsAsync(UpdateMealsRequest Meals);
        Task SoftDeleteMealsAsync(int id);
    }

    public class MealsRepository: IMealsRepository
    {
        private readonly SportNutritionDbContext _context;

        public MealsRepository(SportNutritionDbContext context)
        {
            _context = context;
        }

        public async Task CreateMealsAsync(CreateMealsRequestcs Meals)
        {
            if (Meals == null)
                throw new ArgumentNullException(nameof(Meals));
            var _newMeals = new Meals
            {
                name = Meals.name,
                description = Meals.description,
                calories = Meals.calories,
                protein = Meals.protein,
                carbs = Meals.carbs,
                flat = Meals.flat
            };


            // Agregar el objeto al contexto
            _context.meals.Add(_newMeals);

            // Guardar cambios en la base de datos
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<GetMealsRequest>> GetMealsAsync()
        {
            return await _context.meals
            .Where(s => !s.IsDeleted)
            .Select(s => new GetMealsRequest
            {
                mealsId = s.mealsId,
                name = s.name,
                description = s.description,
                calories = s.calories,
                protein = s.protein,
                carbs = s.carbs,
                flat = s.flat
            })
            .ToListAsync();
        }

        public async Task<Meals> GetMealsByIdAsync(int id)
        {
            return await _context.meals
            .Where(s => s.mealsId == id && !s.IsDeleted)
            .Select(s => new Meals
            {
                mealsId = s.mealsId,
                name = s.name,
                description = s.description,
                calories = s.calories,
                protein = s.protein,
                carbs = s.carbs,
                flat = s.flat
            })
            .FirstOrDefaultAsync();
        }

        public async Task SoftDeleteMealsAsync(int id)
        {
            var meals = await _context.meals.FindAsync(id);
            if (meals != null)
            {
                meals.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateMealsAsync(UpdateMealsRequest Meals)
        {
            if (Meals == null)
                throw new ArgumentNullException(nameof(Meals));

            var existingMeals = await _context.meals.FindAsync(Meals.mealsId);
            if (existingMeals == null)
                throw new ArgumentException($"meals with ID {Meals.mealsId} not found");

            // Actualizar las propiedades del objeto existente
            existingMeals.name = String.IsNullOrEmpty(Meals.name) ? existingMeals.name : Meals.name;
            existingMeals.description = String.IsNullOrEmpty(Meals.description) ? existingMeals.description : Meals.description;
            existingMeals.calories = String.IsNullOrEmpty(Meals.calories) ? existingMeals.calories : Meals.calories;
            existingMeals.protein = String.IsNullOrEmpty(Meals.protein) ? existingMeals.protein : Meals.protein;
            existingMeals.carbs = String.IsNullOrEmpty(Meals.carbs) ? existingMeals.carbs : Meals.carbs;
            existingMeals.flat = String.IsNullOrEmpty(Meals.flat) ? existingMeals.flat : Meals.flat;

            await _context.SaveChangesAsync();
        }
    }
}

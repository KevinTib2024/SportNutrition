using Microsoft.VisualBasic;
using SportNutrition.DTO.NutritionMeals;
using SportNutrition.Model;
using SportNutrition.Repository;

namespace SportNutrition.Service
{
    public interface INutritionMealsService
    {
        Task<IEnumerable<GetNutritionMealsRequest>> GetAllNutritionMealsAsync();
        Task<NutritionMeals> GetNutritionMealsByIdAsync(int id);
        Task CreateNutritionMealsAsync(CreateNutritionMealsRequest NutritionMeals);
        Task UpdateNutritionMealsAsync(UpdateNutritionMealsRequest NutritionMeals);
        Task SoftDeleteNutritionMealsAsync(int id);
    }
    public class NutritionMealsService: INutritionMealsService
    {
        private readonly INutritionMealsRepository _nutritionMealsRepository;

        public NutritionMealsService(INutritionMealsRepository nutritionMealsRepository)
        {
            _nutritionMealsRepository = nutritionMealsRepository;
        }

        public async Task CreateNutritionMealsAsync(CreateNutritionMealsRequest NutritionMeals)
        {
            await _nutritionMealsRepository.CreateNutritionMealsAsync(NutritionMeals);
        }

        public async Task<IEnumerable<GetNutritionMealsRequest>> GetAllNutritionMealsAsync()
        {
            return await _nutritionMealsRepository.GetAllNutritionMealsAsync();
        }

        public async Task<NutritionMeals> GetNutritionMealsByIdAsync(int id)
        {
            return await _nutritionMealsRepository.GetNutritionMealsByIdAsync(id);
        }

        public async Task SoftDeleteNutritionMealsAsync(int id)
        {
            await _nutritionMealsRepository.SoftDeleteNutritionMealsAsync(id);
        }

        public async Task UpdateNutritionMealsAsync(UpdateNutritionMealsRequest NutritionMeals)
        {
            await _nutritionMealsRepository.UpdateNutritionMealsAsync(NutritionMeals);
        }
    }
}

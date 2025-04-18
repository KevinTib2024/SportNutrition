using Microsoft.VisualBasic;
using SportNutrition.DTO.Meals;
using SportNutrition.Model;
using SportNutrition.Repository;

namespace SportNutrition.Service
{
    public interface IMealsService
    {
        Task<IEnumerable<GetMealsRequest>> GetMealsAsync();
        Task<Meals> GetMealsByIdAsync(int id);
        Task CreateMealsAsync(CreateMealsRequestcs Meals);
        Task UpdateMealsAsync(UpdateMealsRequest Meals);
        Task SoftDeleteMealsAsync(int id);
    }

    public class MealsService: IMealsService
    {
        private readonly IMealsRepository _mealsRepository;

        public MealsService(IMealsRepository mealsRepository)
        {
            _mealsRepository = mealsRepository;
        }

        public async Task CreateMealsAsync(CreateMealsRequestcs Meals)
        {
            await _mealsRepository.CreateMealsAsync(Meals);
        }

        public async Task<IEnumerable<GetMealsRequest>> GetMealsAsync()
        {
            return await _mealsRepository.GetMealsAsync();
        }

        public async Task<Meals> GetMealsByIdAsync(int id)
        {
            return await _mealsRepository.GetMealsByIdAsync(id);
        }

        public async Task SoftDeleteMealsAsync(int id)
        {
            await _mealsRepository.SoftDeleteMealsAsync(id);
        }

        public async Task UpdateMealsAsync(UpdateMealsRequest Meals)
        {
            await _mealsRepository.UpdateMealsAsync(Meals);
        }
    }
}

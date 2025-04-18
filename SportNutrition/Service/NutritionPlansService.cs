using Microsoft.VisualBasic;
using SportNutrition.DTO.NutritionPlans;
using SportNutrition.Model;
using SportNutrition.Repository;

namespace SportNutrition.Service
{
    public interface INutritionPlansService
    {
        Task<IEnumerable<GetNutritionPlansRequest>> GetAllNutritionPlansAsync();
        Task<NutritionPlans> GetNutritionPlansByIdAsync(int id);
        Task CreateNutritionPlansAsync(CreateNutritionPlansRequest NutritionPlans);
        Task UpdateNutritionPlansAsync(UpdateNutritionPlansRequest NutritionPlans);
        Task SoftDeleteNutritionPlansAsync(int id);
    }

    public class NutritionPlansService: INutritionPlansService
    {
        private readonly INutritionPlansRepository _nutritionPlansRepository;

        public NutritionPlansService(INutritionPlansRepository nutritionPlansRepository)
        {
            _nutritionPlansRepository = nutritionPlansRepository;
        }

        public async Task CreateNutritionPlansAsync(CreateNutritionPlansRequest NutritionPlans)
        {
            await _nutritionPlansRepository.CreateNutritionPlansAsync(NutritionPlans);
        }

        public async Task<IEnumerable<GetNutritionPlansRequest>> GetAllNutritionPlansAsync()
        {
            return await _nutritionPlansRepository.GetAllNutritionPlansAsync();
        }

        public async Task<NutritionPlans> GetNutritionPlansByIdAsync(int id)
        {
            return await _nutritionPlansRepository.GetNutritionPlansByIdAsync(id);
        }

        public async Task SoftDeleteNutritionPlansAsync(int id)
        {
            await _nutritionPlansRepository.SoftDeleteNutritionPlansAsync(id);
        }

        public async Task UpdateNutritionPlansAsync(UpdateNutritionPlansRequest NutritionPlans)
        {
            await _nutritionPlansRepository.UpdateNutritionPlansAsync(NutritionPlans);
        }
    }
}

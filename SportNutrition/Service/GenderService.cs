using SportNutrition.DTO.Gender;
using SportNutrition.Repository;

namespace SportNutrition.Service
{
    public interface IGenderService
    {
        Task<IEnumerable<GetGenderRequest>> GetAllGenderAsync();
        Task<GetGenderRequest> GetGenderByIdAsync(int id);
        Task CreateGenderAsync(CreateGenderRequest gender);
        Task UpdateGenderAsync(UpdateGenderRequest gender);
        Task SoftDeleteGenderAsync(int id);
    }

    public class GenderService : IGenderService
    {
        private readonly IGenderRepository _genderRepository;

        public GenderService(IGenderRepository genderRepository)
        {
            _genderRepository = genderRepository;
        }

        public async Task CreateGenderAsync(CreateGenderRequest gender)
        {
            await _genderRepository.CreateGenderAsync(gender);
        }

        public async Task<IEnumerable<GetGenderRequest>> GetAllGenderAsync()
        {
            return await _genderRepository.GetAllGenderAsync();
        }

        public async Task<GetGenderRequest> GetGenderByIdAsync(int id)
        {
            return await _genderRepository.GetGenderByIdAsync(id);
        }

        public async Task SoftDeleteGenderAsync(int id)
        {
            await _genderRepository.SoftDeleteGenderAsync(id);
        }

        public async Task UpdateGenderAsync(UpdateGenderRequest gender)
        {
            await _genderRepository.UpdateGenderAsync(gender);
        }
    }
}

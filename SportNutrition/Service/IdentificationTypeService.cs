using SportNutrition.DTO.IdentificationType;
using SportNutrition.Repository;

namespace SportNutrition.Service
{
    public interface IIdentificationTypeService
    {
        Task<IEnumerable<GetIdentificationTypeRequest>> GetAllIdentificationTypeAsync();
        Task<GetIdentificationTypeRequest> GetIdentificationTypeByIdAsync(int id);
        Task CreateIdentificationTypeAsync(CreateIdentificationTypeRequest identificationType);
        Task UpdateIdentificationTypeAsync(UpdateIdentificationTypeRequest identificationType);
        Task SoftDeleteIdentificationTypeAsync(int id);
    }

    public class IdentificationTypeService : IIdentificationTypeService
    {
        private readonly IIdentificationTypeRepository _identificationTypeRepository;

        public IdentificationTypeService(IIdentificationTypeRepository identificationTypeRepository)
        {
            _identificationTypeRepository = identificationTypeRepository;
        }

        public async Task CreateIdentificationTypeAsync(CreateIdentificationTypeRequest identificationType)
        {
            await _identificationTypeRepository.CreateIdentificationTypeAsync(identificationType);
        }

        public async Task<IEnumerable<GetIdentificationTypeRequest>> GetAllIdentificationTypeAsync()
        {
            return await _identificationTypeRepository.GetAllIdentificationTypeAsync();
        }

        public async Task<GetIdentificationTypeRequest> GetIdentificationTypeByIdAsync(int id)
        {
            return await _identificationTypeRepository.GetIdentificationTypeByIdAsync(id);
        }

        public async Task SoftDeleteIdentificationTypeAsync(int id)
        {
            await _identificationTypeRepository.SoftDeleteIdentificationTypeAsync(id);
        }

        public async Task UpdateIdentificationTypeAsync(UpdateIdentificationTypeRequest identificationType)
        {
            await _identificationTypeRepository.UpdateIdentificationTypeAsync(identificationType);
        }
    }
}

using SportNutrition.DTO.UserType;
using SportNutrition.Repository;

namespace SportNutrition.Service
{
    public interface IUserTypeService
    {
        Task<IEnumerable<GetUserTypeRequest>> GetAllUserTypeAsync();
        Task<GetUserTypeRequest> GetUserTypeByIdAsync(int id);
        Task CreateUserTypeAsync(CreateUserTypeRequest userType);
        Task UpdateUserTypeAsync(UpdateUserTypeRequest userType);
        Task SoftDeleteUserTypeAsync(int id);
    }

    public class UserTypeService: IUserTypeService
    {
        private readonly IUserTypeRepository _userTypeRepository;

        public UserTypeService(IUserTypeRepository userTypeRepository)
        {
            _userTypeRepository = userTypeRepository;
        }

        public async Task CreateUserTypeAsync(CreateUserTypeRequest userType)
        {
            await _userTypeRepository.CreateUserTypeAsync(userType);
        }

        public async Task<IEnumerable<GetUserTypeRequest>> GetAllUserTypeAsync()
        {
            return await _userTypeRepository.GetAllUserTypeAsync();
        }

        public async Task<GetUserTypeRequest> GetUserTypeByIdAsync(int id)
        {
            return await _userTypeRepository.GetUserTypeByIdAsync(id);
        }

        public async Task SoftDeleteUserTypeAsync(int id)
        {
            await _userTypeRepository.SoftDeleteUserTypeAsync(id);
        }

        public async Task UpdateUserTypeAsync(UpdateUserTypeRequest userType)
        {
            await _userTypeRepository.UpdateUserTypeAsync(userType);
        }
    }
}

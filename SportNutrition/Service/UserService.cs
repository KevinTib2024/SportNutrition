using SportNutrition.DTO.User;
using SportNutrition.Repository;

namespace SportNutrition.Service
{
    public interface IUserService
    {
        Task<IEnumerable<GetUserRequets>> GetAllUserAsync();
        Task<GetUserRequets> GetUserByIdAsync(int id);
        Task CreateUserAsync(CreateUserRequest user);
        Task UpdateUserAsync(UpdateUserRequest user);
        Task SoftDeleteUserAsync(int id);
        Task<bool> ValidateUserAsync(string email, string password);
    }
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task CreateUserAsync(CreateUserRequest user)
        {
            await _userRepository.CreateUserAsync(user);
        }

        public async Task<IEnumerable<GetUserRequets>> GetAllUserAsync()
        {
            return await _userRepository.GetAllUserAsync();
        }

        public async Task<GetUserRequets> GetUserByIdAsync(int id)
        {
            return await _userRepository.GetUserByIdAsync(id);
        }

        public async Task SoftDeleteUserAsync(int id)
        {
            await _userRepository.SoftDeleteUserAsync(id);
        }

        public async Task UpdateUserAsync(UpdateUserRequest user)
        {
            await _userRepository.UpdateUserAsync(user);
        }

        public async Task<bool> ValidateUserAsync(string email, string password)
        {
            try
            {
                return await _userRepository.ValidateUserAsync(email, password);
            }
            catch (Exception e)
            {
                // Puedes agregar un registro de log aquí para guardar la excepción
                Console.WriteLine($"Error en la validación de usuario: {e.Message}");
                throw;
            }
        }
    }
}

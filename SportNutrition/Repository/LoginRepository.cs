using Microsoft.AspNetCore.Identity;
using SportNutrition.Context;
using SportNutrition.DTO.Login;
using SportNutrition.Model;
using Microsoft.EntityFrameworkCore;

namespace SportNutrition.Repository
{
    public interface ILoginRepository
    {
        Task<LoginResponse> AutenticationAsync(string email, string password); // Cambio a LoginResponse
    }

    public class LoginRepository: ILoginRepository
    {
        private readonly SportNutritionDbContext _context;
        private readonly PasswordHasher<User> _passwordHasher = new PasswordHasher<User>();

        public LoginRepository(SportNutritionDbContext context)
        {
            _context = context;
        }

        public async Task<LoginResponse> AutenticationAsync(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                throw new ArgumentNullException();
            }

            var user = await _context.user.FirstOrDefaultAsync(u => u.email == email);
            if (user == null) return null; // Usuario no encontrado

            var result = _passwordHasher.VerifyHashedPassword(user, user.password, password);
            if (result == PasswordVerificationResult.Success)
            {
                return new LoginResponse
                {
                    Email = user.email,
                    UserTypeId = user.user_Type_Id,  // Asumiendo que el usuario tiene un UserTypeId
                    IsAuthenticated = true
                };
            }

            return null; // Contraseña no válida
        }
    }
}

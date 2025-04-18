using SportNutrition.DTO.User;
using SportNutrition.DTO.Gender;
using SportNutrition.DTO.IdentificationType;
using SportNutrition.DTO.UserType;
using SportNutrition.DTO.Workout;
using SportNutrition.DTO.NutritionPlans;
using SportNutrition.Model;
using SportNutrition.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


namespace SportNutrition.Repository
{
    public interface IUserRepository
    {
        Task<IEnumerable<GetUserRequets>> GetAllUserAsync();
        Task<GetUserRequets> GetUserByIdAsync(int id);
        Task CreateUserAsync(CreateUserRequest user);
        Task UpdateUserAsync(UpdateUserRequest user);
        Task SoftDeleteUserAsync(int id);
        Task<bool> ValidateUserAsync(string email, string password);
    }

    public class UserRepository : IUserRepository
    {
        private readonly SportNutritionDbContext _context;
        private readonly PasswordHasher<User> _passwordHasher = new PasswordHasher<User>(); // Usar PasswordHasher

        public UserRepository(SportNutritionDbContext context)
        {
            _context = context;
        }

        // Método para crear un nuevo usuario con la contraseña hasheada
        public async Task CreateUserAsync(CreateUserRequest user)
        {
            var _typeUser = await _context.userType.FindAsync(user.user_Type_Id);
            var _gender = await _context.gender.FindAsync(user.gender_Id);
            var _identification_Type = await _context.identificationType.FindAsync(user.identificationType_Id);
            var _nutritionPlans = await _context.nutritionPlans.FindAsync(user.nutritionPlans_Id);
            var _workout = await _context.workouts.FindAsync(user.workout_Id);

            if (_identification_Type == null)
            {
                throw new Exception("No se encontro identificacion");
            }

            if (_gender == null)
            {
                throw new Exception("No se encontro  genero");

            }
            if (_typeUser == null)
            {
                throw new Exception("No se encontro tipo de user");
            }
            if (_nutritionPlans == null)
            {
                throw new Exception("No se encontro nutritionPlans");
            }
            if (_workout == null)
            {
                throw new Exception("No se encontro workout");
            }
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            // Hashear la contraseña antes de guardarla en la base de datos
            user.password = _passwordHasher.HashPassword(null, user.password);

            var _newUser = new User
            {
                names = user.names,
                lastNames = user.lastNames,
                identificationNumber = user.identificationNumber,
                gender_Id = user.gender_Id,
                birthDate = user.birthDate,
                email = user.email,
                password = user.password,
                user_Type_Id = user.user_Type_Id,
                identificationType_Id = user.identificationType_Id,
                contact = user.contact,
                height = user.height,
                weight = user.weight,
                workout_Id = user.workout_Id,
                nutritionPlans_Id = user.nutritionPlans_Id


            };

            // Agregar el objeto al contexto
            _context.user.Add(_newUser);

            // Guardar cambios en la base de datos
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<GetUserRequets>> GetAllUserAsync()
        {
            return (IEnumerable<GetUserRequets>)await _context.user
            .Where(s => !s.IsDeleted)
              .Select(s => new GetUserRequets
              {
                  userId = s.userId,
                  user_Type_Id = s.user_Type_Id,
                  names = s.names,
                  lastNames = s.lastNames,
                  identificationType_Id = s.identificationType_Id,
                  identificationNumber = s.identificationNumber,
                  birthDate = s.birthDate,
                  contact = s.contact,
                  gender_Id = s.gender_Id,
                  email = s.email,
                  height = s.height,
                  weight = s.weight,

              })
            .ToListAsync();
        }

        public async Task<GetUserRequets> GetUserByIdAsync(int id)
        {
            return await _context.user
            .Where(s => s.userId == id && !s.IsDeleted)
            .Select(s => new GetUserRequets
            {
                userId = s.userId,
                user_Type_Id = s.user_Type_Id,
                names = s.names,
                lastNames = s.lastNames,
                identificationType_Id = s.identificationType_Id,
                identificationNumber = s.identificationNumber,
                birthDate = s.birthDate,
                contact = s.contact,
                gender_Id = s.gender_Id,
                email = s.email,
                height = s.height,
                weight = s.weight,

         
            })
            .FirstOrDefaultAsync();
        }

        public async Task SoftDeleteUserAsync(int id)
        {
            var user = await _context.user.FindAsync(id);
            if (user != null)
            {
                user.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }

        // Método para actualizar un usuario existente, incluyendo la contraseña si es necesario
        public async Task UpdateUserAsync(UpdateUserRequest user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            var existingUser = await _context.user.FindAsync(user.userId);
            if (existingUser == null)
                throw new ArgumentException($"User with ID {user.userId} not found");

            // Actualizar las propiedades del objeto existente
            existingUser.user_Type_Id = (int)(user.user_Type_Id == null ? existingUser.user_Type_Id : user.user_Type_Id);
            existingUser.identificationType_Id = (int)(user.identificationType_Id == null ? existingUser.identificationType_Id : user.identificationType_Id);
            existingUser.identificationNumber = String.IsNullOrEmpty(user.identificationNumber) ? existingUser.identificationNumber : user.identificationNumber;
            existingUser.names = String.IsNullOrEmpty(user.names) ? existingUser.names : user.names;
            existingUser.lastNames = String.IsNullOrEmpty(user.lastNames) ? existingUser.lastNames : user.lastNames;
            existingUser.birthDate = String.IsNullOrEmpty(user.birthDate) ? existingUser.birthDate : user.birthDate;
            existingUser.contact = String.IsNullOrEmpty(user.contact) ? existingUser.contact : user.contact;
            existingUser.gender_Id = (int)(user.gender_Id == null ? existingUser.gender_Id : user.gender_Id);
            existingUser.email = String.IsNullOrEmpty(user.email) ? existingUser.email : user.email;
            existingUser.height = user.height ?? existingUser.height;
            existingUser.weight = user.weight ?? existingUser.weight;
            existingUser.workout_Id = (int)(user.workout_Id == null ? existingUser.workout_Id : user.workout_Id);
            existingUser.nutritionPlans_Id = (int)(user.nutritionPlans_Id == null ? existingUser.nutritionPlans_Id : user.nutritionPlans_Id);

            // Verificar si la contraseña ha sido cambiada
            if (!string.IsNullOrEmpty(user.password))
            {
                // Hashear la nueva contraseña
                existingUser.password = _passwordHasher.HashPassword(existingUser, user.password);
            }

            await _context.SaveChangesAsync();
        }

        // Método para validar un usuario, verificando la contraseña hasheada
        public async Task<bool> ValidateUserAsync(string email, string password)
        {
            var user = await _context.user.FirstOrDefaultAsync(u => u.email == email);

            if (user == null)
                return false;

            // Verificar la contraseña ingresada con la contraseña hasheada almacenada
            var userVerification = _passwordHasher.VerifyHashedPassword(user, user.password, password);

            return userVerification == PasswordVerificationResult.Success;
        }
    }
}

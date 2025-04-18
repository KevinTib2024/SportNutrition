using Microsoft.EntityFrameworkCore;
using SportNutrition.Context;
using SportNutrition.DTO.Exercises;
using SportNutrition.DTO.Workout;
using SportNutrition.Model;

namespace SportNutrition.Repository
{
    public interface IExercisesRepository
    {
        Task<IEnumerable<GetExercisesRequest>> GetAllExercisesAsync();
        Task<Exercises> GetExercisesByIdAsync(int id);
        Task CreateExercisesAsync(CreateExercisesRequest Exercises);
        Task UpdateExercisesAsync(UpdateExercisesRequest Exercises);
        Task SoftDeleteExercisesAsync(int id);
    }

    public class ExercisesRepository : IExercisesRepository
    {
        private readonly SportNutritionDbContext _context;

        public ExercisesRepository(SportNutritionDbContext context)
        {
            _context = context;
        }

        public async Task CreateExercisesAsync(CreateExercisesRequest Exercises)
        {
            if (Exercises == null)
                throw new ArgumentNullException(nameof(Exercises));
            var _newExercises = new Exercises
            {
                name = Exercises.name,
                description = Exercises.description,
                muscleGroup = Exercises.muscleGroup

            };


            // Agregar el objeto al contexto
            _context.exercises.Add(_newExercises);

            // Guardar cambios en la base de datos
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<GetExercisesRequest>> GetAllExercisesAsync()
        {
            return await _context.exercises
            .Where(s => !s.IsDeleted)
            .Select(s => new GetExercisesRequest
            {
                exercisesId = s.exercisesId,
                name = s.name,
                description = s.description,
                muscleGroup = s.muscleGroup
            })
            .ToListAsync();
        }

        public async Task<Exercises> GetExercisesByIdAsync(int id)
        {
            return await _context.exercises
            .Where(s => s.exercisesId == id && !s.IsDeleted)
            .Select(s => new Exercises
            {
                exercisesId = s.exercisesId,
                name = s.name,
                description = s.description,
                muscleGroup = s.muscleGroup
            })
            .FirstOrDefaultAsync();
        }

        public async Task SoftDeleteExercisesAsync(int id)
        {
            var exercises = await _context.exercises.FindAsync(id);
            if (exercises != null)
            {
                exercises.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateExercisesAsync(UpdateExercisesRequest Exercises)
        {
            if (Exercises == null)
                throw new ArgumentNullException(nameof(Exercises));

            var existingExercises = await _context.exercises.FindAsync(Exercises.exercisesId);
            if (existingExercises == null)
                throw new ArgumentException($"workout with ID {Exercises.exercisesId} not found");

            // Actualizar las propiedades del objeto existente
            existingExercises.name = String.IsNullOrEmpty(Exercises.name) ? existingExercises.name : Exercises.name;
            existingExercises.description = String.IsNullOrEmpty(Exercises.description) ? existingExercises.description : Exercises.description;
            existingExercises.muscleGroup = String.IsNullOrEmpty(Exercises.muscleGroup) ? existingExercises.muscleGroup : Exercises.muscleGroup;

            await _context.SaveChangesAsync();
        }
    }
}

using SportNutrition.Context;
using SportNutrition.DTO.Exercises;
using SportNutrition.DTO.WorkoutExercises;
using SportNutrition.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace SportNutrition.Repository
{
    public interface IWorkoutExercisesRepository
    {
        Task<IEnumerable<GetWorkoutExercisesRequest>> GetAllWorkoutExercisesAsync();
        Task<GetWorkoutExercisesRequest> GetWorkoutExercisesByIdAsync(int id);
        Task CreateWorkoutExercisesAsync(CreateWorkoutExercisesRequest WorkoutExercises);
        Task UpdateWorkoutExercisesAsync(UpdateWorkoutExercisesRequest WorkoutExercises);
        Task SoftDeleteWorkoutExercisesAsync(int id);
    }

    public class WorkoutExercisesRepository: IWorkoutExercisesRepository
    {
        private readonly SportNutritionDbContext _context;

        public WorkoutExercisesRepository(SportNutritionDbContext context)
        {
            _context = context;
        }

        public async Task CreateWorkoutExercisesAsync(CreateWorkoutExercisesRequest workoutExercises)
        {
            var _workout = await _context.workouts.FindAsync(workoutExercises.workout_Id);
            var _exercises = await _context.exercises.FindAsync(workoutExercises.exercises_Id);

            if (_workout == null)
            {
                throw new Exception("No se encontro un entrenamiento");
            }

            if (_exercises == null)
            {
                throw new Exception("No se encontro un ejercicio");
            }

            if (workoutExercises == null)
                throw new ArgumentNullException(nameof(workoutExercises));
            var _newWorkoutExercises = new WorkoutExercises
            {
                workout_Id = workoutExercises.workout_Id,
                exercises_Id = workoutExercises.exercises_Id,
                sets = workoutExercises.sets,
                reps = workoutExercises.reps,
                restSeconds = workoutExercises.restSeconds

            };


            // Agregar el objeto al contexto
            _context.workoutExercises.Add(_newWorkoutExercises);

            // Guardar cambios en la base de datos
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<GetWorkoutExercisesRequest>> GetAllWorkoutExercisesAsync()
        {
            return await _context.workoutExercises
             .Where(s => !s.IsDeleted)
             .Select(s => new GetWorkoutExercisesRequest
             {
                 workoutExercisesId = s.workoutExercisesId,
                 workout_Id = s.workout_Id,
                 exercises_Id = s.exercises_Id,
                 sets = s.sets,
                 reps = s.reps,
                 restSeconds = s.restSeconds
             })
             .ToListAsync();
        }

        public async Task<GetWorkoutExercisesRequest> GetWorkoutExercisesByIdAsync(int id)
        {
            return await _context.workoutExercises
            .Where(s => s.workoutExercisesId == id && !s.IsDeleted)
            .Select(s => new GetWorkoutExercisesRequest
            {
                workoutExercisesId = s.workoutExercisesId,
                workout_Id = s.workout_Id,
                exercises_Id = s.exercises_Id,
                sets = s.sets,
                reps = s.reps,
                restSeconds = s.restSeconds
            })
            .FirstOrDefaultAsync();
        }

        public async Task SoftDeleteWorkoutExercisesAsync(int id)
        {
            var WorkoutExercises = await _context.workoutExercises.FindAsync(id);
            if (WorkoutExercises != null)
            {
                WorkoutExercises.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateWorkoutExercisesAsync(UpdateWorkoutExercisesRequest WorkoutExercises)
        {
            if (WorkoutExercises == null)
                throw new ArgumentNullException(nameof(WorkoutExercises));

            var existingWorkoutExercises = await _context.workoutExercises.FindAsync(WorkoutExercises.workoutExercisesId);
            if (existingWorkoutExercises == null)
                throw new ArgumentException($"WorkoutExercises with ID {WorkoutExercises.workoutExercisesId} not found");

            // Actualizar las propiedades del objeto existente
            existingWorkoutExercises.workout_Id = (int)(WorkoutExercises.workout_Id == null ? existingWorkoutExercises.workout_Id : WorkoutExercises.workout_Id);
            existingWorkoutExercises.exercises_Id = (int)(WorkoutExercises.exercises_Id == null ? existingWorkoutExercises.exercises_Id : WorkoutExercises.exercises_Id);
            existingWorkoutExercises.sets = WorkoutExercises.sets ?? existingWorkoutExercises.sets;
            existingWorkoutExercises.reps = WorkoutExercises.reps ?? existingWorkoutExercises.reps;
            existingWorkoutExercises.restSeconds = WorkoutExercises.restSeconds ?? existingWorkoutExercises.restSeconds;

            await _context.SaveChangesAsync();
        }
    }
}

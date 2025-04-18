using Microsoft.EntityFrameworkCore;
using SportNutrition.Context;
using SportNutrition.DTO.Permissions;
using SportNutrition.DTO.Workout;
using SportNutrition.Model;

namespace SportNutrition.Repository
{
    public interface IWorkoutRepository
    {
        Task<IEnumerable<GetWorkoutRequest>> GetAllWorkoutsAsync();
        Task<Workout> GetWorkoutsByIdAsync(int id);
        Task CreateWorkoutsAsync(CreateWorkoutRequest workouts);
        Task UpdateWorkoutsAsync(UpdateWorkoutRequest workouts);
        Task SoftDeleteWorkoutsAsync(int id);
    }

    public class WorkoutRepository : IWorkoutRepository
    {
        private readonly SportNutritionDbContext _context;

        public WorkoutRepository(SportNutritionDbContext context)
        {
            _context = context;
        }

        public async Task CreateWorkoutsAsync(CreateWorkoutRequest workouts)
        {
            if (workouts == null)
                throw new ArgumentNullException(nameof(workouts));
            var _newWorkouts = new Workout
            {
                name = workouts.name,
                description = workouts.description,
                difficultyLevel = workouts.difficultyLevel,
                duration = workouts.duration,
                goal = workouts.goal

            };


            // Agregar el objeto al contexto
            _context.workouts.Add(_newWorkouts);    

            // Guardar cambios en la base de datos
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<GetWorkoutRequest>> GetAllWorkoutsAsync()
        {
            return await _context.workouts
            .Where(s => !s.IsDeleted)
            .Select(s => new GetWorkoutRequest 
            {  workoutId = s.workoutId,
                name = s.name,
                description = s.description,
                difficultyLevel= s.difficultyLevel,
                duration =s.duration,
                goal = s.goal })
            .ToListAsync();
        }

        public async Task<Workout> GetWorkoutsByIdAsync(int id)
        {
            return await _context.workouts
            .Where(s => s.workoutId == id && !s.IsDeleted)
            .Select(s => new Workout 
            {   workoutId = s.workoutId,
                name = s.name,
                description = s.description,
                difficultyLevel = s.difficultyLevel,
                duration = s.duration,
                goal = s.goal})
            .FirstOrDefaultAsync();
        }

        public async Task SoftDeleteWorkoutsAsync(int id)
        {
            var workout = await _context.workouts.FindAsync(id);
            if (workout != null)
            {
                workout.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateWorkoutsAsync(UpdateWorkoutRequest workouts)
        {
            if (workouts == null)
                throw new ArgumentNullException(nameof(workouts));

            var existingWorkout = await _context.workouts.FindAsync(workouts.workoutId);
            if (existingWorkout == null)
                throw new ArgumentException($"workout with ID {workouts.workoutId} not found");

            // Actualizar las propiedades del objeto existente
            existingWorkout.name = String.IsNullOrEmpty(workouts.name) ? existingWorkout.name : workouts.name;
            existingWorkout.description = String.IsNullOrEmpty(workouts.description) ? existingWorkout.description : workouts.description;
            existingWorkout.difficultyLevel = String.IsNullOrEmpty(workouts.difficultyLevel) ? existingWorkout.difficultyLevel : workouts.difficultyLevel;
            existingWorkout.duration = String.IsNullOrEmpty(workouts.duration) ? existingWorkout.duration : workouts.duration;
            existingWorkout.goal = String.IsNullOrEmpty(workouts.goal) ? existingWorkout.goal : workouts.goal;

            await _context.SaveChangesAsync();
        }
    }
}

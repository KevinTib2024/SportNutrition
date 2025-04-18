using Microsoft.VisualBasic;
using SportNutrition.DTO.Workout;
using SportNutrition.Model;
using SportNutrition.Repository;
namespace SportNutrition.Service
{
    public interface IWorkoutService
    {
        Task<IEnumerable<GetWorkoutRequest>> GetAllWorkoutsAsync();
        Task<Workout> GetWorkoutsByIdAsync(int id);
        Task CreateWorkoutsAsync(CreateWorkoutRequest workouts);
        Task UpdateWorkoutsAsync(UpdateWorkoutRequest workouts);
        Task SoftDeleteWorkoutsAsync(int id);
    }

    public class WorkoutService: IWorkoutService
    {
        private readonly IWorkoutRepository _workoutRepository;

        public WorkoutService(IWorkoutRepository workoutRepository)
        {
            _workoutRepository = workoutRepository;
        }

        public async Task CreateWorkoutsAsync(CreateWorkoutRequest workouts)
        {
            await _workoutRepository.CreateWorkoutsAsync(workouts);
        }

        public async Task<IEnumerable<GetWorkoutRequest>> GetAllWorkoutsAsync()
        {
            return await _workoutRepository.GetAllWorkoutsAsync();
        }

        public async Task<Workout> GetWorkoutsByIdAsync(int id)
        {
            return await _workoutRepository.GetWorkoutsByIdAsync(id);
        }

        public async Task SoftDeleteWorkoutsAsync(int id)
        {
            await _workoutRepository.SoftDeleteWorkoutsAsync(id);
        }

        public async Task UpdateWorkoutsAsync(UpdateWorkoutRequest workouts)
        {
            await _workoutRepository.UpdateWorkoutsAsync(workouts);
        }
    }
}

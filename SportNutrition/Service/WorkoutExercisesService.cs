using Microsoft.VisualBasic;
using SportNutrition.DTO.WorkoutExercises;
using SportNutrition.Repository; 

namespace SportNutrition.Service
{
    public interface IWorkoutExercisesService
    {
        Task<IEnumerable<GetWorkoutExercisesRequest>> GetAllWorkoutExercisesAsync();
        Task<GetWorkoutExercisesRequest> GetWorkoutExercisesByIdAsync(int id);
        Task CreateWorkoutExercisesAsync(CreateWorkoutExercisesRequest WorkoutExercises);
        Task UpdateWorkoutExercisesAsync(UpdateWorkoutExercisesRequest WorkoutExercises);
        Task SoftDeleteWorkoutExercisesAsync(int id);
    }

    public class WorkoutExercisesService: IWorkoutExercisesService
    {
        private readonly IWorkoutExercisesRepository _workoutExercisesRepository;

        public WorkoutExercisesService(IWorkoutExercisesRepository workoutExercisesRepository)
        {
            _workoutExercisesRepository = workoutExercisesRepository;
        }

        public async Task CreateWorkoutExercisesAsync(CreateWorkoutExercisesRequest WorkoutExercises)
        {
            await _workoutExercisesRepository.CreateWorkoutExercisesAsync(WorkoutExercises);
        }

        public async Task<IEnumerable<GetWorkoutExercisesRequest>> GetAllWorkoutExercisesAsync()
        {
            return await _workoutExercisesRepository.GetAllWorkoutExercisesAsync();
        }

        public async Task<GetWorkoutExercisesRequest> GetWorkoutExercisesByIdAsync(int id)
        {
            return await _workoutExercisesRepository.GetWorkoutExercisesByIdAsync(id);
        }

        public async Task SoftDeleteWorkoutExercisesAsync(int id)
        {
            await _workoutExercisesRepository.SoftDeleteWorkoutExercisesAsync(id);
        }

        public async Task UpdateWorkoutExercisesAsync(UpdateWorkoutExercisesRequest WorkoutExercises)
        {
            await _workoutExercisesRepository.UpdateWorkoutExercisesAsync(WorkoutExercises);
        }
    }
}

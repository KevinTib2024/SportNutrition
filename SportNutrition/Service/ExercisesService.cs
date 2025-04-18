using SportNutrition.DTO.Exercises;
using SportNutrition.Model;
using SportNutrition.Repository;

namespace SportNutrition.Service
{
    public interface IExercisesService
    {
        Task<IEnumerable<GetExercisesRequest>> GetAllExercisesAsync();
        Task<Exercises> GetExercisesByIdAsync(int id);
        Task CreateExercisesAsync(CreateExercisesRequest Exercises);
        Task UpdateExercisesAsync(UpdateExercisesRequest Exercises);
        Task SoftDeleteExercisesAsync(int id);
    }

    public class ExercisesService: IExercisesService
    {
        private readonly IExercisesRepository _exercisesRepository;

        public ExercisesService(IExercisesRepository exercisesRepository)
        {
            _exercisesRepository = exercisesRepository;
        }

        public async Task CreateExercisesAsync(CreateExercisesRequest Exercises)
        {
            await _exercisesRepository.CreateExercisesAsync(Exercises);
        }

        public async Task<IEnumerable<GetExercisesRequest>> GetAllExercisesAsync()
        {
            return await _exercisesRepository.GetAllExercisesAsync();
        }
         
        public async Task<Exercises> GetExercisesByIdAsync(int id)
        {
            return await _exercisesRepository.GetExercisesByIdAsync(id);
        }

        public async Task SoftDeleteExercisesAsync(int id)
        {
            await _exercisesRepository.SoftDeleteExercisesAsync(id);
        }

        public async Task UpdateExercisesAsync(UpdateExercisesRequest Exercises)
        {
            await _exercisesRepository.UpdateExercisesAsync(Exercises);
        }
    }
}

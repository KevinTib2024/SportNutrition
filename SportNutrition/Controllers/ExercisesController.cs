using Microsoft.AspNetCore.Mvc;
using SportNutrition.DTO.Exercises;
using SportNutrition.DTO.WorkoutExercises;
using SportNutrition.Model;
using SportNutrition.Service;

namespace SportNutrition.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ExercisesController:ControllerBase
    {
        private readonly IExercisesService _exercisesService;

        public ExercisesController(IExercisesService exercisesService)
        {

            _exercisesService = exercisesService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult<IEnumerable<GetExercisesRequest>>> GetAllExercises()
        {
            var exercises = await _exercisesService.GetAllExercisesAsync();
            return Ok(exercises);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Exercises>> GetExercisesById(int id)
        {
            var exercises = await _exercisesService.GetExercisesByIdAsync(id);
            if (exercises == null)
                return NotFound();

            return Ok(exercises);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateWorkoutExercises([FromBody] CreateExercisesRequest exercises)
        {
            await _exercisesService.CreateExercisesAsync(exercises);
            return CreatedAtAction(nameof(GetExercisesById), new { id = exercises }, exercises);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateExercises([FromBody] UpdateExercisesRequest exercises)
        {

            var existingExercises = await _exercisesService.GetExercisesByIdAsync(exercises.exercisesId);
            if (existingExercises == null)
                return NotFound();

            await _exercisesService.UpdateExercisesAsync(exercises);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SoftDeleteExercises(int id)
        {
            var exercises = await _exercisesService.GetExercisesByIdAsync(id);
            if (exercises == null)
                return NotFound();

            await _exercisesService.SoftDeleteExercisesAsync(id);
            return NoContent();
        }
    }
}

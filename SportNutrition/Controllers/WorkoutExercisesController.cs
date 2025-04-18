using Microsoft.AspNetCore.Mvc;
using SportNutrition.DTO.Workout;
using SportNutrition.DTO.WorkoutExercises;
using SportNutrition.Model;
using SportNutrition.Service;

namespace SportNutrition.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class WorkoutExercisesController:ControllerBase
    {
        private readonly IWorkoutExercisesService _workoutExercisesService;

        public WorkoutExercisesController(IWorkoutExercisesService workoutExercisesService)
        {

            _workoutExercisesService = workoutExercisesService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult<IEnumerable<GetWorkoutExercisesRequest>>> GetAllWorkoutExercises()
        {
            var workoutExercises = await _workoutExercisesService.GetAllWorkoutExercisesAsync();
            return Ok(workoutExercises);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WorkoutExercises>> GetWorkoutExercisesById(int id)
        {
            var workoutExercises = await _workoutExercisesService.GetWorkoutExercisesByIdAsync(id);
            if (workoutExercises == null)
                return NotFound();

            return Ok(workoutExercises);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateWorkoutExercises([FromBody] CreateWorkoutExercisesRequest workoutExercises)
        {
            await _workoutExercisesService.CreateWorkoutExercisesAsync(workoutExercises);
            return CreatedAtAction(nameof(GetWorkoutExercisesById), new { id = workoutExercises }, workoutExercises);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateWorkoutExercises([FromBody] UpdateWorkoutExercisesRequest workoutExercises)
        {

            var existingWorkoutExercises = await _workoutExercisesService.GetWorkoutExercisesByIdAsync(workoutExercises.workoutExercisesId);
            if (existingWorkoutExercises == null)
                return NotFound();

            await _workoutExercisesService.UpdateWorkoutExercisesAsync(workoutExercises);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SoftDeleteWorkoutExercises(int id)
        {
            var workoutExercises = await _workoutExercisesService.GetWorkoutExercisesByIdAsync(id);
            if (workoutExercises == null)
                return NotFound();

            await _workoutExercisesService.SoftDeleteWorkoutExercisesAsync(id);
            return NoContent();
        }
    }
}


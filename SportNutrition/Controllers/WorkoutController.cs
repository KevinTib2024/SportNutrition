using Microsoft.AspNetCore.Mvc;
using SportNutrition.DTO.Meals;
using SportNutrition.DTO.Workout;
using SportNutrition.Model;
using SportNutrition.Service;

namespace SportNutrition.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class WorkoutController:ControllerBase
    {
        private readonly IWorkoutService _workoutService;

        public WorkoutController(IWorkoutService workoutService)
        {

            _workoutService = workoutService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult<IEnumerable<GetWorkoutRequest>>> GetAllWorkout()
        {
            var workout = await _workoutService.GetAllWorkoutsAsync();
            return Ok(workout);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Workout>> GetWorkoutById(int id)
        {
            var workout = await _workoutService.GetWorkoutsByIdAsync(id);
            if (workout == null)
                return NotFound();

            return Ok(workout);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateWorkout([FromBody] CreateWorkoutRequest workout)
        {
            await _workoutService.CreateWorkoutsAsync(workout);
            return CreatedAtAction(nameof(GetWorkoutById), new { id = workout }, workout);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateWorkout([FromBody] UpdateWorkoutRequest workout)
        {

            var existingWorkout = await _workoutService.GetWorkoutsByIdAsync(workout.workoutId);
            if (existingWorkout == null)
                return NotFound();

            await _workoutService.UpdateWorkoutsAsync(workout);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SoftDeleteWorkout(int id)
        {
            var workout = await _workoutService.GetWorkoutsByIdAsync(id);
            if (workout == null)
                return NotFound();

            await _workoutService.SoftDeleteWorkoutsAsync(id);
            return NoContent();
        }
    }
}


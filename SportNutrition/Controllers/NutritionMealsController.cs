using Microsoft.AspNetCore.Mvc;
using SportNutrition.DTO.NutritionMeals;
using SportNutrition.DTO.Permissions;
using SportNutrition.Model;
using SportNutrition.Service;

namespace SportNutrition.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class NutritionMealsController:ControllerBase
    {
        private readonly INutritionMealsService _nutritionMealsService;

        public NutritionMealsController(INutritionMealsService nutritionMealsService)
        {

            _nutritionMealsService = nutritionMealsService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult<IEnumerable<GetNutritionMealsRequest>>> GetAllNutritionMeals()
        {
            var nutritionMeals = await _nutritionMealsService.GetAllNutritionMealsAsync();
            return Ok(nutritionMeals);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<NutritionMeals>> GetNutritionMealsById(int id)
        {
            var nutritionMeals = await _nutritionMealsService.GetNutritionMealsByIdAsync(id);
            if (nutritionMeals == null)
                return NotFound();

            return Ok(nutritionMeals);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateNutritionMeals([FromBody] CreateNutritionMealsRequest nutritionMeals)
        {
            await _nutritionMealsService.CreateNutritionMealsAsync(nutritionMeals);
            return CreatedAtAction(nameof(GetNutritionMealsById), new { id = nutritionMeals }, nutritionMeals);
        }
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateNutritionMeals([FromBody] UpdateNutritionMealsRequest nutritionMeals)
        {

            var existingNutritionMeals = await _nutritionMealsService.GetNutritionMealsByIdAsync(nutritionMeals.nutritionMealsId);
            if (existingNutritionMeals == null)
                return NotFound();

            await _nutritionMealsService.UpdateNutritionMealsAsync(nutritionMeals);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SoftDeleteNutritionMeals(int id)
        {
            var nutritionMeals = await _nutritionMealsService.GetNutritionMealsByIdAsync(id);
            if (nutritionMeals == null)
                return NotFound();

            await _nutritionMealsService.SoftDeleteNutritionMealsAsync(id);
            return NoContent();
        }
    }
}

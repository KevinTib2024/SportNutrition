using Microsoft.AspNetCore.Mvc;
using SportNutrition.DTO.Meals;
using SportNutrition.DTO.NutritionMeals;
using SportNutrition.Model;
using SportNutrition.Service;

namespace SportNutrition.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class MealsController:ControllerBase
    {
        private readonly IMealsService _mealsService;

        public MealsController(IMealsService mealsService)
        {

            _mealsService = mealsService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult<IEnumerable<GetMealsRequest>>> GetAllMeals()
        {
            var meals = await _mealsService.GetMealsAsync();
            return Ok(meals);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Meals>> GetMealsById(int id)
        {
            var meals = await _mealsService.GetMealsByIdAsync(id);
            if (meals == null)
                return NotFound();

            return Ok(meals);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateMeals([FromBody] CreateMealsRequestcs meals)
        {
            await _mealsService.CreateMealsAsync(meals);
            return CreatedAtAction(nameof(GetMealsById), new { id = meals }, meals);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateMeals([FromBody] UpdateMealsRequest meals)
        {

            var existingMeals = await _mealsService.GetMealsByIdAsync(meals.mealsId);
            if (existingMeals == null)
                return NotFound();

            await _mealsService.UpdateMealsAsync(meals);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SoftDeleteMeals(int id)
        {
            var meals = await _mealsService.GetMealsByIdAsync(id);
            if (meals == null)
                return NotFound();

            await _mealsService.SoftDeleteMealsAsync(id);
            return NoContent();
        }
    }
}


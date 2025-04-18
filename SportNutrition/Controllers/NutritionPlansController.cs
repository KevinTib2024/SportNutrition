using Microsoft.AspNetCore.Mvc;
using SportNutrition.DTO.NutritionMeals;
using SportNutrition.DTO.NutritionPlans;
using SportNutrition.Model;
using SportNutrition.Service;

namespace SportNutrition.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class NutritionPlansController:ControllerBase
    {
        private readonly INutritionPlansService _nutritionPlansService;

        public NutritionPlansController(INutritionPlansService nutritionPlansService)
        {

            _nutritionPlansService = nutritionPlansService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult<IEnumerable<GetNutritionPlansRequest>>> GetAllNutritionPlans()
        {
            var nutritionPlans = await _nutritionPlansService.GetAllNutritionPlansAsync();
            return Ok(nutritionPlans);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<NutritionPlans>> GetNutritionPlansById(int id)
        {
            var nutritionPlans = await _nutritionPlansService.GetNutritionPlansByIdAsync(id);
            if (nutritionPlans == null)
                return NotFound();

            return Ok(nutritionPlans);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateNutritionPlans([FromBody] CreateNutritionPlansRequest nutritionPlans)
        {
            await _nutritionPlansService.CreateNutritionPlansAsync(nutritionPlans);
            return CreatedAtAction(nameof(GetNutritionPlansById), new { id = nutritionPlans }, nutritionPlans);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateNutritionPlans([FromBody] UpdateNutritionPlansRequest nutritionPlans)
        {

            var existingNutritionPlans = await _nutritionPlansService.GetNutritionPlansByIdAsync(nutritionPlans.nutritionPlansId);
            if (existingNutritionPlans == null)
                return NotFound();

            await _nutritionPlansService.UpdateNutritionPlansAsync(nutritionPlans);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SoftDeleteNutritionPlans(int id)
        {
            var nutritionPlans = await _nutritionPlansService.GetNutritionPlansByIdAsync(id);
            if (nutritionPlans == null)
                return NotFound();

            await _nutritionPlansService.SoftDeleteNutritionPlansAsync(id);
            return NoContent();
        }
    }
}


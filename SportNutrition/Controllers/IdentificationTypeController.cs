using Microsoft.AspNetCore.Mvc;
using SportNutrition.DTO.IdentificationType;
using SportNutrition.Service;

namespace SportNutrition.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class IdentificationTypeController: ControllerBase
    {
        private readonly IIdentificationTypeService _identificationTypeService;

        public IdentificationTypeController(IIdentificationTypeService identificationTypeService)
        {

            _identificationTypeService = identificationTypeService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult<IEnumerable<GetIdentificationTypeRequest>>> GetAllIdentificationType()
        {
            var identificationTypes = await _identificationTypeService.GetAllIdentificationTypeAsync();
            return Ok(identificationTypes);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GetIdentificationTypeRequest>> GetIdentificationTypeById(int id)
        {
            var identificationType = await _identificationTypeService.GetIdentificationTypeByIdAsync(id);
            if (identificationType == null)
                return NotFound();

            return Ok(identificationType);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateIdentificationType([FromBody] CreateIdentificationTypeRequest identificationType)
        {
            await _identificationTypeService.CreateIdentificationTypeAsync(identificationType);
            return CreatedAtAction(nameof(GetIdentificationTypeById), new { id = identificationType }, identificationType);
        }
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateIdentificationType([FromBody] UpdateIdentificationTypeRequest identificationType)
        {
            var existingIdentificationType = await _identificationTypeService.GetIdentificationTypeByIdAsync(identificationType.IdentificationTypeId);
            if (existingIdentificationType == null)
                return NotFound();

            await _identificationTypeService.UpdateIdentificationTypeAsync(identificationType);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SoftDeleteIdentificationType(int id)
        {
            var identificationType = await _identificationTypeService.GetIdentificationTypeByIdAsync(id);
            if (identificationType == null)
                return NotFound();

            await _identificationTypeService.SoftDeleteIdentificationTypeAsync(id);
            return NoContent();
        }
    }
}

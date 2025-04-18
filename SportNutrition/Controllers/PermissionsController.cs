using Microsoft.AspNetCore.Mvc;
using SportNutrition.DTO.Permissions;
using SportNutrition.Model;
using SportNutrition.Service;

namespace SportNutrition.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class PermissionsController:ControllerBase
    {
        private readonly IPermissionsService _permissionsService;

        public PermissionsController(IPermissionsService permissionsService)
        {

            _permissionsService = permissionsService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult<IEnumerable<GetPermissionsRequestcs>>> GetAllPermissions()
        {
            var permissions = await _permissionsService.GetAllPermissionsAsync();
            return Ok(permissions);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Permissions>> GetPermissionsById(int id)
        {
            var permissions = await _permissionsService.GetPermissionsByIdAsync(id);
            if (permissions == null)
                return NotFound();

            return Ok(permissions);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreatePermissions([FromBody] CreatePermissionsRequest permissions)
        {
            await _permissionsService.CreatePermissionsAsync(permissions);
            return CreatedAtAction(nameof(GetPermissionsById), new { id = permissions }, permissions);
        }
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdatePermissions([FromBody] UpdatePermissionsRequest permissions)
        {

            var existingPermissions = await _permissionsService.GetPermissionsByIdAsync(permissions.permissionsId);
            if (existingPermissions == null)
                return NotFound();

            await _permissionsService.UpdatePermissionsAsync(permissions);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SoftDeletePermissions(int id)
        {
            var permissions = await _permissionsService.GetPermissionsByIdAsync(id);
            if (permissions == null)
                return NotFound();

            await _permissionsService.SoftDeletePermissionsAsync(id);
            return NoContent();
        }
    }
}

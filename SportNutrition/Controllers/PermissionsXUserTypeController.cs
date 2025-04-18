using Microsoft.AspNetCore.Mvc;
using SportNutrition.DTO.PermissionsXUserType;
using SportNutrition.Model;
using SportNutrition.Service;

namespace SportNutrition.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class PermissionsXUserTypeController:ControllerBase
    {
        private readonly IPermissionsXUserTypeService _permissionXUserTypeService;

        public PermissionsXUserTypeController(IPermissionsXUserTypeService permissionXUserTypeService)
        {

            _permissionXUserTypeService = permissionXUserTypeService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<GetPermissionsXUserTypeRequest>>> GetAllPermissionXUserType()
        {
            var permissionXUserType = await _permissionXUserTypeService.GetAllPermissionXUserTypeAsync();
            return Ok(permissionXUserType);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PermissionXUserType>> GetPermissionXUserTypeById(int id)
        {
            var permissionXUserType = await _permissionXUserTypeService.GetPermissionXUserTypeByIdAsync(id);
            if (permissionXUserType == null)
                return NotFound();

            return Ok(permissionXUserType);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreatePermissionXUserType([FromBody] CreatePermissionsXUserTypeRequest permissionXUserType)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _permissionXUserTypeService.CreatePermissionXUserTypeAsync(permissionXUserType);
            return CreatedAtAction(nameof(GetPermissionXUserTypeById), new { id = permissionXUserType}, permissionXUserType);
        }
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdatePermissionXUserType(int id, [FromBody] updatePermissionsXUserTypeRequest permissionXUserType)
        {
            if (id != permissionXUserType.permissionXUserTypeId)
                return BadRequest();

            var existingPermissionXUserType = await _permissionXUserTypeService.GetPermissionXUserTypeByIdAsync(id);
            if (existingPermissionXUserType == null)
                return NotFound();

            await _permissionXUserTypeService.UpdatePermissionXUserTypeAsync(permissionXUserType);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SoftDeletePermissionXUserType(int id)
        {
            var permissionXUserType = await _permissionXUserTypeService.GetPermissionXUserTypeByIdAsync(id);
            if (permissionXUserType == null)
                return NotFound();

            await _permissionXUserTypeService.SoftDeletePermissionXUserTypeAsync(id);
            return NoContent();
        }

        [HttpGet("validate")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult> ValidatePermissions(int userType_Id, int permissions_Id)
        {
            bool hasPermissions = await _permissionXUserTypeService.HasPermissionAsync(userType_Id, permissions_Id);

            if (hasPermissions)
            {
                return Ok(new { Message = "User has the required permission." });
            }

            return StatusCode(StatusCodes.Status403Forbidden, "User does not have the required permission.");
        }
    }
}

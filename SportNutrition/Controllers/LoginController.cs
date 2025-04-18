using Microsoft.AspNetCore.Mvc;
using SportNutrition.DTO.Login;
using SportNutrition.Service;

namespace SportNutrition.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class LoginController:ControllerBase
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<LoginResponse>> AutenticationAsync([FromBody] LoginRequest loginRequest)
        {
            var loginResponse = await _loginService.AutenticationAsync(loginRequest.Email, loginRequest.Password);

            if (loginResponse == null)
            {
                return BadRequest("Credenciales incorrectas");
            }

            return Ok(loginResponse);
        }
    }
}

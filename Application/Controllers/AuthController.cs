namespace VG.backend.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using VG.backend.Authentication;
    using VG.Common.Params.Auth;
    using VG.Services.Interfaces;

    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public IAuthService AuthService { get; set; }

        public AuthController(IAuthService authService)
        {
            this.AuthService = authService;
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] Registration register)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                this.AuthService.SaveUser(register);
                return Ok("User registered successfully.");
            }
            catch (Exception ex)
            {
                // In production, log the exception properly using ILogger
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] Login login)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = AuthService.AuthenticateUser(login.Email, login.Password);

            if (user == null)
            {
                return Unauthorized("Invalid email or password.");
            }

            return Ok("User logged in successfully.");
        }
    }
}

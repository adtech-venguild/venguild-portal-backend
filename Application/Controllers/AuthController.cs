namespace VG.backend.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using VG.backend.Authentication;
    using VG.Common.Params.Auth;

    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public AuthService AuthService { get; set; }
        [HttpPost("register")]
        public IActionResult Register([FromBody] Registration register)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Registration logic here (e.g., save to DB, send confirmation email, etc.)
            return Ok("User registered successfully.");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] Login login)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Authenticate the user (check email and password)
            // If successful, return a JWT or session info
            // await AuthService.GenerateToken(login);


            return Ok("User logged in successfully.");
        }
    }
}

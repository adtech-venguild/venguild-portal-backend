namespace VG.backend.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
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
        public async Task<IActionResult> Register([FromBody] Registration register)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!register.Password.Equals(register.ConfirmedPassword))
            {
                return BadRequest(ModelState);
            }

            await this.AuthService.SaveUserAsync(register);

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
   
            var result = await this.AuthService.LoginUserAsync(login);

            if (result.Item1 == null)
            {
                return BadRequest(result.Item2);
            }

            return Ok("User logged in successfully.");
        }
    }
}

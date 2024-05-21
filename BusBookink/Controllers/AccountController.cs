using BusBookink.Bl;
using BusBookink.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BusBookink.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AccountController(IAuthService authService)
        {
            this._authService = authService;
        }

        //Registration (New User)
        [HttpPost("signup")]
        public async Task<IActionResult> Register(RegisterModel registerModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (await _authService.Register(registerModel))
            {
                return Ok("Successfully");
            }
            return BadRequest("Something went worng");

        }

        //Login
        [HttpPost("signin")]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (await _authService.Login(loginModel))
            {
                return Ok(_authService.GenerateToken(loginModel));
            }
            return BadRequest("Something went worng");
        }
    }
}

using Application.Contracts;
using Application.DTOs.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUser user;

        public UserController(IUser user)
        {
            this.user = user;
        }

        [HttpPost("login")]
        public async Task<ActionResult<LoginResponse>> Login(LoginDTO loginDTO)
        {
            var result = await user.LoginAsync(loginDTO);
            return Ok(result);
        }

        [HttpPost("register")]
        public async Task<ActionResult<RegistrationResponse>> Register(RegisterDTO registerDTO)
        {
            var result = await user.RegisterAsync(registerDTO);
            return Ok(result);
        }
    }
}

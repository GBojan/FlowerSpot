using FlowerSpot.Domain.Users;
using FlowerSpot.Service.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FlowerSpot.Api.Controllers
{
    [ApiController]
    [AllowAnonymous]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<LoginResponseModel>> Login([FromBody] LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var loginResult = await _userService.LoginAsync(model);

            if (loginResult.IsSuccessful)
            {
                return Ok(loginResult);
            }

            return StatusCode(StatusCodes.Status500InternalServerError, loginResult);
        }

        [HttpPost("register")]
        public async Task<ActionResult<RegisterResponseModel>> Register([FromBody] RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var registerResult = await _userService.RegisterAsync(model);

            if (registerResult.Status == "Success")
            {
                return Ok(registerResult);
            }

            return StatusCode(StatusCodes.Status500InternalServerError, registerResult);
        }
    }
}
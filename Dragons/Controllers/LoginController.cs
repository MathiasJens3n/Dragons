using Dragons.Interfaces;
using Dragons.Models;
using Dragons.Services;
using Microsoft.AspNetCore.Mvc;

namespace Dragons.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly TokenService _tokenService;
        private readonly IUserRepository _userRepository;

        public LoginController(IUserRepository userRepository, TokenService tokenService)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> AddUser([FromBody] User user)
        {
            // Runs if the _userRepository.AddUser executed without errors.
            if (await _userRepository.AddUser(user))
            {
                return Ok(user.Name + " has been added");
            }
            return BadRequest("Error");
        }

        [HttpPost]
        public ActionResult Login([FromBody] User user)
        {
            var userAuthendicated = LoginService.ValidateLogin(user, _userRepository);

            if (userAuthendicated)
            {
                var token = _tokenService.GenerateJwtToken(user);
                return Ok(new { Token = token });
            }

            return Unauthorized();
        }
    }
}
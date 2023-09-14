using Dragons.Interfaces;
using Dragons.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dragons.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DragonController : ControllerBase
    {
        private readonly TokenService _tokenService;
        private readonly IUserRepository _userRepository;

        private readonly List<string> playlist = new List<string>
        {
            "1. Dragon's Midnight Flight",
            "2. Whispers of the Drage",
            "3. Dragonfire Serenade",
            "4. Drage Dancing under the Stars",
            "5. The Dragon and the Dreamer",
            "6. Echoes of a Drage's Roar",
            "7. Dragon's Lullaby",
            "8. Sapphire Drage Skies",
            "9. The Drage's Secret Melody",
            "10. Realm of the Fire Dragon"
        };

        public DragonController(IUserRepository userRepository, TokenService tokenService)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
        }

        [Authorize(Roles="listener")]
        [HttpGet("dragetunes")]
        public async Task<IActionResult> GetPlaylist()
        {
            return Ok(playlist);
        }
    }
}
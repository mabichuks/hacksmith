using Microsoft.AspNetCore.Mvc;
using MuRewards.Core.Interfaces;

namespace MuRewards.Api.Controllers
{
    [ApiController]
    [Route("api/v1/profile")]
    public class ProfileController : ControllerBase
    {
        private readonly IProfileManager _profileManager;

        public ProfileController(IProfileManager profileManager)
        {
            _profileManager = profileManager;
        }

        [HttpGet("email")]
        public IActionResult GetProfile(string email)
        {
            var result = _profileManager.GetProfileByEmail(email);
            return Ok(result);
        }
    }
}

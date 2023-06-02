 using Microsoft.AspNetCore.Mvc;
 using MuRewards.Core.Interfaces;
using MuRewards.Core.Models;

namespace MuRewards.Api.Controllers
{
    [ApiController]
    [Route("api/v1/rewards")]
    public class RewardController : ControllerBase
    {
        private readonly IRewardRequestManager _rewardManager;

        public RewardController(IRewardRequestManager rewardManager)
        {
            _rewardManager = rewardManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetRewards([FromQuery] Guid managerId, [FromQuery] string email = null, [FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var result = await _rewardManager.GetRewardsByManagerId(managerId, email, page, pageSize);
            return Ok(result);
        }

        [HttpPut("update-status")]
        public async Task<IActionResult> UpdateRequestStatus([FromBody] UpdateRequestStatusModel updateModel)
        {
            var response = await _rewardManager.UpdateRequestStatus(updateModel);
            if (response.Succeeded)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }
    }
}
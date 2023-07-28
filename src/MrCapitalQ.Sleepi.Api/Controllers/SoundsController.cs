using Microsoft.AspNetCore.Mvc;

namespace MrCapitalQ.Sleepi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SoundsController : ControllerBase
    {
        [HttpPut("Play", Name = nameof(PlaySounds))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public IActionResult PlaySounds()
        {
            return NoContent();
        }

        [HttpPut("Stop", Name = nameof(StopSounds))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public IActionResult StopSounds()
        {
            return NoContent();
        }
    }
}

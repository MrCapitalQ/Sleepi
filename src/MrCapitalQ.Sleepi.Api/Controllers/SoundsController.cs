using Microsoft.AspNetCore.Mvc;
using MrCapitalQ.Sleepi.Api.Services;

namespace MrCapitalQ.Sleepi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SoundsController : ControllerBase
    {
        private readonly ISoundPlayer _soundPlayer;

        public SoundsController(ISoundPlayer soundPlayer)
        {
            _soundPlayer = soundPlayer;
        }

        [HttpPut("Play", Name = nameof(PlaySounds))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public IActionResult PlaySounds()
        {
            _soundPlayer.Play();

            return NoContent();
        }

        [HttpPut("Stop", Name = nameof(StopSounds))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public IActionResult StopSounds()
        {
            _soundPlayer.Stop();

            return NoContent();
        }
    }
}

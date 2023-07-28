using Microsoft.AspNetCore.Mvc;

namespace MrCapitalQ.Sleepi.Api.Tests.Controllers
{
    public class SoundsControllerTests
    {
        private readonly SoundsController _controller;

        public SoundsControllerTests()
        {
            _controller = new SoundsController();
        }

        [Fact]
        public void PlaySounds_ReturnsNoContent()
        {
            var result = _controller.PlaySounds();

            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public void StopSounds_ReturnsNoContent()
        {
            var result = _controller.StopSounds();

            Assert.IsType<NoContentResult>(result);
        }
    }
}
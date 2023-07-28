using Microsoft.AspNetCore.Mvc;
using Moq;
using MrCapitalQ.Sleepi.Api.Services;

namespace MrCapitalQ.Sleepi.Api.Tests.Controllers
{
    public class SoundsControllerTests
    {
        private readonly Mock<ISoundPlayer> _soundPlayer = new();

        private readonly SoundsController _controller;

        public SoundsControllerTests()
        {
            _controller = new(_soundPlayer.Object);
        }

        [Fact]
        public void PlaySounds_CallsPlay()
        {
            var result = _controller.PlaySounds();

            Assert.IsType<NoContentResult>(result);
            _soundPlayer.Verify(x => x.Play(), Times.Once);
        }

        [Fact]
        public void StopSounds_CallsStop()
        {
            var result = _controller.StopSounds();

            Assert.IsType<NoContentResult>(result);
            _soundPlayer.Verify(x => x.Stop(), Times.Once);
        }
    }
}
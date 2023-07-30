using Microsoft.AspNetCore.Mvc;

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
        public void PlaySounds_DefaultParams_CallsPlay()
        {
            var result = _controller.PlaySounds();

            Assert.IsType<NoContentResult>(result);
            _soundPlayer.Verify(x => x.Play(SoundType.Rain), Times.Once);
        }

        [Theory]
        [InlineData(SoundType.Rain)]
        public void PlaySounds_WithSoundType_CallsPlayWithSoundType(SoundType soundType)
        {
            var result = _controller.PlaySounds(soundType);

            Assert.IsType<NoContentResult>(result);
            _soundPlayer.Verify(x => x.Play(soundType), Times.Once);
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
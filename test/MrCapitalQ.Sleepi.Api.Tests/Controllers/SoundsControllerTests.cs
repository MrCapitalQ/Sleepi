using Microsoft.AspNetCore.Mvc;

namespace MrCapitalQ.Sleepi.Api.Tests.Controllers
{
    public class SoundsControllerTests
    {
        private readonly ISoundPlayer _soundPlayer = Substitute.For<ISoundPlayer>();

        private readonly SoundsController _controller;

        public SoundsControllerTests()
        {
            _controller = new(_soundPlayer);
        }

        [Fact]
        public void PlaySounds_DefaultParams_CallsPlay()
        {
            var result = _controller.PlaySounds();

            Assert.IsType<NoContentResult>(result);
            _soundPlayer.Received(1).Play(SoundType.Rain);
        }

        [Theory]
        [InlineData(SoundType.Rain)]
        public void PlaySounds_WithSoundType_CallsPlayWithSoundType(SoundType soundType)
        {
            var result = _controller.PlaySounds(soundType);

            Assert.IsType<NoContentResult>(result);
            _soundPlayer.Received(1).Play(soundType);
        }

        [Fact]
        public void StopSounds_CallsStop()
        {
            var result = _controller.StopSounds();

            Assert.IsType<NoContentResult>(result);
            _soundPlayer.Received(1).Stop();
        }
    }
}
using Microsoft.AspNetCore.Http.HttpResults;
using MrCapitalQ.Sleepi.Api.Endpoints;

namespace MrCapitalQ.Sleepi.Api.Tests.Endpoints
{
    public class SoundsEndpointsTests
    {
        private readonly ISoundPlayer _soundPlayer = Substitute.For<ISoundPlayer>();

        [Fact]
        public void PlaySounds_DefaultParams_CallsPlay()
        {
            var result = SoundsEndpoints.PlaySounds(_soundPlayer);

            Assert.IsType<NoContent>(result);
            _soundPlayer.Received(1).Play(SoundType.Rain);
        }

        [Theory]
        [InlineData(SoundType.Rain)]
        [InlineData(SoundType.Brown)]
        public void PlaySounds_WithSoundType_CallsPlayWithSoundType(SoundType soundType)
        {
            var result = SoundsEndpoints.PlaySounds(_soundPlayer, soundType);

            Assert.IsType<NoContent>(result);
            _soundPlayer.Received(1).Play(soundType);
        }

        [Fact]
        public void StopSounds_CallsStop()
        {
            var result = SoundsEndpoints.StopSounds(_soundPlayer);

            Assert.IsType<NoContent>(result);
            _soundPlayer.Received(1).Stop();
        }
    }
}

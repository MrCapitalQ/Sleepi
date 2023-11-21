using Microsoft.AspNetCore.Http.HttpResults;
using MrCapitalQ.Sleepi.Api.Endpoints;

namespace MrCapitalQ.Sleepi.Api.Tests.Endpoints
{
    public class SoundsEndpointsTests
    {
        private readonly ISoundPlayer _soundPlayer = Substitute.For<ISoundPlayer>();

        [Fact]
        public async Task PlaySoundsAsync_DefaultParams_CallsPlayAsync()
        {
            var result = await SoundsEndpoints.PlaySoundsAsync(_soundPlayer);

            Assert.IsType<NoContent>(result);
            await _soundPlayer.Received(1).PlayAsync(SoundType.Rain);
        }

        [Theory]
        [InlineData(SoundType.Rain)]
        [InlineData(SoundType.Brown)]
        public async Task PlaySoundsAsync_WithSoundType_CallsPlayAsyncWithSoundType(SoundType soundType)
        {
            var result = await SoundsEndpoints.PlaySoundsAsync(_soundPlayer, soundType);

            Assert.IsType<NoContent>(result);
            await _soundPlayer.Received(1).PlayAsync(soundType);
        }

        [Fact]
        public async Task StopSounds_CallsStopAsync()
        {
            var result = await SoundsEndpoints.StopSoundsAsync(_soundPlayer);

            Assert.IsType<NoContent>(result);
            await _soundPlayer.Received(1).StopAsync();
        }
    }
}

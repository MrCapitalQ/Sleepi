using Microsoft.Extensions.Configuration;

namespace MrCapitalQ.Sleepi.Api.Tests.Services
{
    public class SoundFilePathFactoryTests
    {
        private const string _testWebRootPath = "sounds";
        private readonly SoundFilePathFactory _soundFilePathFactory;

        public SoundFilePathFactoryTests()
        {
            var inMemorySettings = new Dictionary<string, string?>
            {
                { "SoundsRootDirectory", _testWebRootPath }
            };

            var configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(inMemorySettings)
                .Build();
            _soundFilePathFactory = new(configuration);
        }

        [Fact]
        public void GetFilePath_ReturnsAbsoluteFilePath()
        {
            var actual = _soundFilePathFactory.GetFilePath();

            Assert.Equal(Path.Combine(_testWebRootPath, "rain.mp3"), actual);
        }
    }
}

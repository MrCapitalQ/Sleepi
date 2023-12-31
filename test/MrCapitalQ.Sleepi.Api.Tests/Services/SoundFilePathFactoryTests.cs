﻿using Microsoft.Extensions.Configuration;

namespace MrCapitalQ.Sleepi.Api.Tests.Services
{
    public class SoundFilePathFactoryTests
    {
        private const string TestWebRootPath = "sounds";
        private readonly SoundFilePathFactory _soundFilePathFactory;

        public SoundFilePathFactoryTests()
        {
            var inMemorySettings = new Dictionary<string, string?>
            {
                { "SoundsRootDirectory", TestWebRootPath }
            };

            var configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(inMemorySettings)
                .Build();
            _soundFilePathFactory = new(configuration);
        }

        [Theory]
        [InlineData(SoundType.Rain, "rain.mp3")]
        [InlineData(SoundType.Brown, "brown.mp3")]
        public void GetFilePath_ReturnsAbsoluteFilePath(SoundType soundType, string expectedFileName)
        {
            var actual = _soundFilePathFactory.GetFilePath(soundType);

            Assert.Equal(Path.Combine(TestWebRootPath, expectedFileName), actual);
        }
    }
}

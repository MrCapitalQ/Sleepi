namespace MrCapitalQ.Sleepi.Api.Services
{
    public class SoundFilePathFactory : ISoundFilePathFactory
    {
        private readonly IConfiguration _configuration;

        public SoundFilePathFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetFilePath()
        {
            return Path.Combine(_configuration.GetValue<string>("SoundsRootDirectory") ?? string.Empty, "rain.mp3");
        }
    }
}

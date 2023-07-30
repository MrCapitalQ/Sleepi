namespace MrCapitalQ.Sleepi.Api.Services
{
    public class SoundFilePathFactory : ISoundFilePathFactory
    {
        private readonly IConfiguration _configuration;

        public SoundFilePathFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetFilePath(SoundType soundType)
        {
            var fileName = soundType switch
            {
                SoundType.Rain => "rain.mp3",
                _ => "notFound.mp3",
            };
            return Path.Combine(_configuration.GetValue<string>("SoundsRootDirectory") ?? string.Empty, fileName);
        }
    }
}

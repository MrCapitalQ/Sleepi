namespace MrCapitalQ.Sleepi.Api.Services
{
    public interface ISoundPlayer
    {
        Task PlayAsync(SoundType soundType);
        Task StopAsync();
    }
}
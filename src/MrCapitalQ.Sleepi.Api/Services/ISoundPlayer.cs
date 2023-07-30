namespace MrCapitalQ.Sleepi.Api.Services
{
    public interface ISoundPlayer
    {
        void Play(SoundType soundType);
        void Stop();
    }
}
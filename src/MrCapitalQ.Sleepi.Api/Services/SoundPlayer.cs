using LibVLCSharp.Shared;

namespace MrCapitalQ.Sleepi.Api.Services
{
    public sealed class SoundPlayer : ISoundPlayer, IAsyncDisposable
    {
        private readonly ISoundFilePathFactory _soundFilePathFactory;
        private readonly IBluetoothSpeakerManager _speakerManager;
        private readonly LibVLC _libVlc;
        private readonly MediaPlayer _mediaPlayer;

        public SoundPlayer(ISoundFilePathFactory soundFilePathFactory, IBluetoothSpeakerManager speakerManager)
        {
            _soundFilePathFactory = soundFilePathFactory;
            _speakerManager = speakerManager;
            _libVlc = new();
            _mediaPlayer = new(_libVlc);
        }

        public async Task PlayAsync(SoundType soundType)
        {
            await StopAsync();

            var path = _soundFilePathFactory.GetFilePath(soundType);
            if (!Path.Exists(path))
            {
                throw new IOException($"File does not exist at path {path}");
            }

            await _speakerManager.ConnectAsync();

            _mediaPlayer.Media = new Media(_libVlc, new Uri(path));
            _mediaPlayer.Play();
        }

        public async Task StopAsync()
        {
            _mediaPlayer.Stop();
            var media = _mediaPlayer.Media;
            _mediaPlayer.Media = null;
            media?.Dispose();

            await _speakerManager.DisconnectAsync();
        }

        public async ValueTask DisposeAsync()
        {
            await StopAsync();
            _mediaPlayer.Dispose();
            _libVlc.Dispose();
        }
    }
}

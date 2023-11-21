using System.Diagnostics;

namespace MrCapitalQ.Sleepi.Api.Services
{
    public sealed class SoundPlayer : ISoundPlayer, IAsyncDisposable
    {
        private readonly ISoundFilePathFactory _soundFilePathFactory;
        private readonly IBluetoothSpeakerManager _speakerManager;
        private Process? _process;

        public SoundPlayer(ISoundFilePathFactory soundFilePathFactory, IBluetoothSpeakerManager speakerManager)
        {
            _soundFilePathFactory = soundFilePathFactory;
            _speakerManager = speakerManager;
        }

        public async Task PlayAsync(SoundType soundType)
        {
            if (_process is not null)
            {
                _process.Kill();
                _process = null;
            }

            var path = _soundFilePathFactory.GetFilePath(soundType);
            if (!Path.Exists(path))
            {
                throw new IOException($"File does not exist at path {path}");
            }

            await _speakerManager.ConnectAsync();

            _process = new Process()
            {
                StartInfo = new()
                {
                    FileName = "cvlc",
                    Arguments = path,
                    CreateNoWindow = true
                }
            };

            _process.Start();
        }

        public async Task StopAsync()
        {
            if (_process is null)
                return;

            _process.Kill();
            _process = null;

            await _speakerManager.DisconnectAsync();
        }

        public async ValueTask DisposeAsync() => await StopAsync();
    }
}

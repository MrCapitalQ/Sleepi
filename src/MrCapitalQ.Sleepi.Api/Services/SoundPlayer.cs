using System.Diagnostics;

namespace MrCapitalQ.Sleepi.Api.Services
{
    public sealed class SoundPlayer : ISoundPlayer, IDisposable
    {
        private readonly ISoundFilePathFactory _soundFilePathFactory;
        private readonly IBluetoothSpeakerManager _speakerManager;
        private Process? _process;

        public SoundPlayer(ISoundFilePathFactory soundFilePathFactory, IBluetoothSpeakerManager speakerManager)
        {
            _soundFilePathFactory = soundFilePathFactory;
            _speakerManager = speakerManager;
        }

        public void Play(SoundType soundType)
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

            _speakerManager.Connect();

            _process = new Process()
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "cvlc",
                    Arguments = path,
                    CreateNoWindow = true
                }
            };

            _process.Start();
        }

        public void Stop()
        {
            if (_process is null)
                return;

            _process.Kill();
            _process = null;

            _speakerManager.Disconnect();
        }

        public void Dispose()
        {
            Stop();
        }
    }
}

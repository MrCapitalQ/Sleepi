using System.Diagnostics;

namespace MrCapitalQ.Sleepi.Api.Services
{
    public class SoundPlayer : ISoundPlayer
    {
        private readonly ISoundFilePathFactory _soundFilePathFactory;
        private Process? _process;

        public SoundPlayer(ISoundFilePathFactory soundFilePathFactory)
        {
            _soundFilePathFactory = soundFilePathFactory;
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

            _process = new Process()
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "cvlc",
                    Arguments = path,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
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
        }
    }
}

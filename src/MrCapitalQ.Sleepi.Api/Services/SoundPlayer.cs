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

        public void Play()
        {
            if (_process is not null)
            {
                _process.Kill();
                _process = null;
            }

            var path = _soundFilePathFactory.GetFilePath();
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
            if (_process is not null)
            {
                _process.Kill();
                _process = null;
            }
        }
    }
}

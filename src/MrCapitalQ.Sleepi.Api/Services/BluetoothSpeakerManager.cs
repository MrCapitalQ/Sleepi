using System.Diagnostics;

namespace MrCapitalQ.Sleepi.Api.Services
{
    public class BluetoothSpeakerManager : IBluetoothSpeakerManager
    {
        private const string SpeakerMacAddressKey = "BluetoothSpeakerMacAddress";
        private readonly IConfiguration _configuration;

        public BluetoothSpeakerManager(IConfiguration configuration) => _configuration = configuration;

        public async Task ConnectAsync()
        {
            var bluetoothSpeakerMacAddress = _configuration.GetValue<string>(SpeakerMacAddressKey);
            if (string.IsNullOrEmpty(bluetoothSpeakerMacAddress))
                return;

            var process = new Process()
            {
                StartInfo = new()
                {
                    FileName = "bluetoothctl",
                    Arguments = $"connect {bluetoothSpeakerMacAddress}",
                    UseShellExecute = false,
                    CreateNoWindow = true
                }
            };
            process.Start();
            await process.WaitForExitAsync();
        }

        public async Task DisconnectAsync()
        {
            var bluetoothSpeakerMacAddress = _configuration.GetValue<string>(SpeakerMacAddressKey);
            if (string.IsNullOrEmpty(bluetoothSpeakerMacAddress))
                return;

            var process = new Process()
            {
                StartInfo = new()
                {
                    FileName = "bluetoothctl",
                    Arguments = $"disconnect {bluetoothSpeakerMacAddress}",
                    CreateNoWindow = true
                }
            };
            process.Start();
            await process.WaitForExitAsync();
        }
    }
}

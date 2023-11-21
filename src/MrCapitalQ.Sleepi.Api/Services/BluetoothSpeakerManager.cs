using System.Diagnostics;

namespace MrCapitalQ.Sleepi.Api.Services
{
    public class BluetoothSpeakerManager : IBluetoothSpeakerManager
    {
        private const string SpeakerMacAddressKey = "BluetoothSpeakerMacAddress";
        private readonly IConfiguration _configuration;

        public BluetoothSpeakerManager(IConfiguration configuration) => _configuration = configuration;

        public void Connect()
        {
            var bluetoothSpeakerMacAddress = _configuration.GetValue<string>(SpeakerMacAddressKey);
            if (string.IsNullOrEmpty(bluetoothSpeakerMacAddress))
                return;

            new Process()
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "bluetoothctl",
                    Arguments = $"connect {bluetoothSpeakerMacAddress}",
                    CreateNoWindow = true
                }
            }.Start();
        }

        public void Disconnect()
        {
            var bluetoothSpeakerMacAddress = _configuration.GetValue<string>(SpeakerMacAddressKey);
            if (string.IsNullOrEmpty(bluetoothSpeakerMacAddress))
                return;

            new Process()
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "bluetoothctl",
                    Arguments = $"disconnect {bluetoothSpeakerMacAddress}",
                    CreateNoWindow = true
                }
            }.Start();
        }
    }
}

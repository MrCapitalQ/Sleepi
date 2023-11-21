namespace MrCapitalQ.Sleepi.Api.Services
{
    public interface IBluetoothSpeakerManager
    {
        Task ConnectAsync();
        Task DisconnectAsync();
    }
}

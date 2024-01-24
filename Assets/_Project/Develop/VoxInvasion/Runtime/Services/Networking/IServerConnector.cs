namespace VoxInvasion.Runtime.Services.Networking
{
    public interface IServerConnector
    {
        void Connect();
        void Disconnect();
    }
}
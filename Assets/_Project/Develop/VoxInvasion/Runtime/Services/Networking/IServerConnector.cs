namespace VoxInvasion.Runtime.Services.Networking
{
    public interface IServerConnector
    {
        void Connect(string ip, ushort port);
        void Disconnect();
    }
}
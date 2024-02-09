namespace VoxInvasion.Backend.Connection
{
    public interface IServerConnector
    {
        void Connect();
        void Disconnect();
    }
}
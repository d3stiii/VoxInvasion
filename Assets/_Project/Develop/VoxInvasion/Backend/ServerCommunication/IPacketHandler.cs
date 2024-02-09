using VoxInvasion.Backend.Connection;

namespace VoxInvasion.Backend.ServerCommunication
{
    public interface IPacketHandler
    {
        PacketId Id { get; }
        void Execute(IPacket packet, Client client);
    }
}
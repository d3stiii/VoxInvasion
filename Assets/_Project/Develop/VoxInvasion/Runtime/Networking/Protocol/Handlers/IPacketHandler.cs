using VoxInvasion.Runtime.Networking.Protocol.Packets;

namespace VoxInvasion.Runtime.Networking.Protocol.Handlers
{
    public interface IPacketHandler
    {
        PacketId Id { get; }
        void Execute(IPacket packet, Client client);
    }
}
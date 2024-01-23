namespace VoxInvasion.Runtime.Networking.Packets
{
    public interface IPacketHandler
    {
        PacketId Id { get; }
        void Execute(IPacket packet, Client client);
    }
}
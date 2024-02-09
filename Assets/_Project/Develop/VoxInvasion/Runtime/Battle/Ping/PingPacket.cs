using ProtoBuf;
using VoxInvasion.Backend.Connection;
using VoxInvasion.Backend.ServerCommunication;

namespace VoxInvasion.Runtime.Battle.Ping
{
    [ProtoContract]
    public class PingPacket : IPacket
    {
        [ProtoMember(1)] public PacketId Id { get; } = PacketId.Ping;
        [ProtoMember(2)] public long UnixMilliseconds { get; set; }
    }

    public class PingHandler : IPacketHandler
    {
        public PacketId Id { get; } = PacketId.Ping;

        public void Execute(IPacket packet, Client client)
        {
            var pingPacket = (PingPacket)packet;
            client.SendAsync(new PongPacket { ClientUnixMilliseconds = pingPacket.UnixMilliseconds });
        }
    }
}
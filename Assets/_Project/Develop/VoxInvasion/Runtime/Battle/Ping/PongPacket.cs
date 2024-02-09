using ProtoBuf;
using VoxInvasion.Backend.ServerCommunication;

namespace VoxInvasion.Runtime.Battle.Ping
{
    [ProtoContract]
    public class PongPacket : IPacket
    {
        [ProtoMember(1)] public PacketId Id { get; } = PacketId.Pong;
        [ProtoMember(2)] public long ClientUnixMilliseconds { get; set; }
    }
}
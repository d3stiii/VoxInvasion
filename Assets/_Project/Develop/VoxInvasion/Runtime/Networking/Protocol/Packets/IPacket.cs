using ProtoBuf;
using VoxInvasion.Runtime.Networking.Protocol.Packets.Common;

namespace VoxInvasion.Runtime.Networking.Protocol.Packets
{
    [ProtoContract]
    [ProtoInclude(100, typeof(WelcomePacket))]
    [ProtoInclude(200, typeof(PingPacket))]
    public interface IPacket
    {
        PacketId Id { get; }
    }
}
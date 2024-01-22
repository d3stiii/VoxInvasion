using ProtoBuf;
using VoxInvasion.Runtime.Networking.Protocol.Packets.Common;

namespace VoxInvasion.Runtime.Networking.Protocol.Packets
{
    [ProtoContract]
    [ProtoInclude(100, typeof(WelcomePacket))]
    public interface IPacket
    {
        PacketId Id { get; }
    }
}
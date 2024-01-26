using ProtoBuf;

namespace VoxInvasion.Runtime.Networking.Packets.Entrance.Validation
{
    [ProtoContract]
    public class CheckEmailPacket : IPacket
    {
        [ProtoMember(1)] public PacketId Id { get; } = PacketId.CheckEmail;
        [ProtoMember(2)] public string Email { get; set; } = null!;
    }
}
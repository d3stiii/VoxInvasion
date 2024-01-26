using ProtoBuf;

namespace VoxInvasion.Runtime.Networking.Packets.Entrance.Validation
{
    [ProtoContract]
    public class CheckUsernamePacket : IPacket
    {
        [ProtoMember(1)] public PacketId Id { get; } = PacketId.CheckUsername;
        [ProtoMember(2)] public string Username { get; set; } = null!;
    }
}
using ProtoBuf;
using VoxInvasion.Backend.ServerCommunication;

namespace VoxInvasion.Runtime.Entrance.Validation
{
    [ProtoContract]
    public class CheckEmailPacket : IPacket
    {
        [ProtoMember(1)] public PacketId Id { get; } = PacketId.CheckEmail;
        [ProtoMember(2)] public string Email { get; set; } = null!;
    }
}
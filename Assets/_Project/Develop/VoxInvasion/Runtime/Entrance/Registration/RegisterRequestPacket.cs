using ProtoBuf;
using VoxInvasion.Backend.ServerCommunication;

namespace VoxInvasion.Runtime.Entrance.Registration
{
    [ProtoContract]
    public class RegisterRequestPacket : IPacket
    {
        [ProtoMember(1)] public PacketId Id { get; } = PacketId.RegisterRequest;
        [ProtoMember(2)] public string Username { get; set; }
        [ProtoMember(3)] public string Email { get; set; }
        [ProtoMember(4)] public string Password { get; set; }
    }
}
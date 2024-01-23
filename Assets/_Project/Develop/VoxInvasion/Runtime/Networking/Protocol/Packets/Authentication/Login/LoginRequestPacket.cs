using ProtoBuf;

namespace VoxInvasion.Runtime.Networking.Protocol.Packets.Authentication.Login
{
    [ProtoContract]
    public class LoginRequestPacket : IPacket
    {
        [ProtoMember(1)] public PacketId Id { get; } = PacketId.LoginRequest;
        [ProtoMember(2)] public string Username { get; set; }
        [ProtoMember(3)] public string Password { get; set; }
    }
}
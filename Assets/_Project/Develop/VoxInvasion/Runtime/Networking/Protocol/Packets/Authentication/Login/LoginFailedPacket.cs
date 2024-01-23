using ProtoBuf;

namespace VoxInvasion.Runtime.Networking.Protocol.Packets.Authentication.Login
{
    [ProtoContract]
    public class LoginFailedPacket : IPacket
    {
        [ProtoMember(1)] public PacketId Id { get; } = PacketId.LoginFailed;
    }
}
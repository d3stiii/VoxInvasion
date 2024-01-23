using ProtoBuf;

namespace VoxInvasion.Runtime.Networking.Protocol.Packets.Authentication.Login
{
    [ProtoContract]
    public class LoginSuccessPacket : IPacket
    {
        [ProtoMember(1)] public PacketId Id { get; } = PacketId.LoginSuccess;
    }
}
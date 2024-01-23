using ProtoBuf;
using VoxInvasion.Runtime.Networking.Protocol.Packets.Authentication.Login;
using VoxInvasion.Runtime.Networking.Protocol.Packets.Authentication.Registration;
using VoxInvasion.Runtime.Networking.Protocol.Packets.Common;

namespace VoxInvasion.Runtime.Networking.Protocol.Packets
{
    [ProtoContract]
    [ProtoInclude(100, typeof(WelcomePacket))]
    [ProtoInclude(200, typeof(PingPacket))]
    [ProtoInclude(300, typeof(LoginRequestPacket))]
    [ProtoInclude(400, typeof(RegisterRequestPacket))]
    public interface IPacket
    {
        PacketId Id { get; }
    }
}
using ProtoBuf;
using VoxInvasion.Runtime.Networking.Packets.Entrance;
using VoxInvasion.Runtime.Networking.Packets.Entrance.Login;
using VoxInvasion.Runtime.Networking.Packets.Entrance.Registration;
using VoxInvasion.Runtime.Networking.Packets.Ping;

namespace VoxInvasion.Runtime.Networking.Packets
{
    [ProtoContract]
    [ProtoInclude(100, typeof(WelcomePacket))]
    [ProtoInclude(200, typeof(PingPacket))]
    [ProtoInclude(300, typeof(LoginRequestPacket))]
    [ProtoInclude(400, typeof(RegisterRequestPacket))]
    [ProtoInclude(500, typeof(RegistrationFailedPacket))]
    [ProtoInclude(600, typeof(LoginSuccessPacket))]
    [ProtoInclude(700, typeof(LoginFailedPacket))]
    [ProtoInclude(800, typeof(PongPacket))]
    [ProtoInclude(900, typeof(PingResultPacket))]
    public interface IPacket
    {
        PacketId Id { get; }
    }
}
using ProtoBuf;
using VoxInvasion.Runtime.Battle.Ping;
using VoxInvasion.Runtime.Bootstrap;
using VoxInvasion.Runtime.Entrance.Login;
using VoxInvasion.Runtime.Entrance.Registration;
using VoxInvasion.Runtime.Entrance.Validation;

namespace VoxInvasion.Backend.ServerCommunication
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
    [ProtoInclude(1000, typeof(CheckEmailPacket))]
    [ProtoInclude(1100, typeof(EmailInvalidPacket))]
    [ProtoInclude(1200, typeof(EmailOccupiedPacket))]
    [ProtoInclude(1300, typeof(EmailValidPacket))]
    [ProtoInclude(1400, typeof(CheckUsernamePacket))]
    [ProtoInclude(1500, typeof(UsernameOccupiedPacket))]
    [ProtoInclude(1600, typeof(UsernameValidPacket))]
    public interface IPacket
    {
        PacketId Id { get; }
    }
}
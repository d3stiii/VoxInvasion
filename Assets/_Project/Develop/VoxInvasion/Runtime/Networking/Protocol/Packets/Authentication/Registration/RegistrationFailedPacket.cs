using ProtoBuf;

namespace VoxInvasion.Runtime.Networking.Protocol.Packets.Authentication.Registration
{
    [ProtoContract]
    public class RegistrationFailedPacket : IPacket
    {
        [ProtoMember(1)] public PacketId Id { get; } = PacketId.RegistrationFailed;
    }
}
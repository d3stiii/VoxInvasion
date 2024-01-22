using System;
using ProtoBuf;

namespace VoxInvasion.Runtime.Networking.Protocol.Packets.Common
{
    [ProtoContract]
    public class PingPacket : IPacket
    {
        [ProtoMember(1)] public PacketId Id { get; } = PacketId.Ping;
        [ProtoMember(2)] public long UnixMilliseconds { get; set; }

        public DateTimeOffset CurrentTime
        {
            get => DateTimeOffset.FromUnixTimeMilliseconds(UnixMilliseconds);
            set => UnixMilliseconds = value.ToUnixTimeMilliseconds();
        }
    }
}
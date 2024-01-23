using System;
using ProtoBuf;
using UnityEngine;

namespace VoxInvasion.Runtime.Networking.Packets.Ping
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

    public class PingHandler : IPacketHandler
    {
        public PacketId Id { get; } = PacketId.Ping;

        public void Execute(IPacket packet, Client client)
        {
            var pingPacket = (PingPacket)packet;
            Debug.Log((DateTimeOffset.UtcNow - pingPacket.CurrentTime).Milliseconds);
        }
    }
}
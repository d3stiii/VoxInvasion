using System;
using UnityEngine;
using VoxInvasion.Runtime.Networking.Protocol.Packets;
using VoxInvasion.Runtime.Networking.Protocol.Packets.Common;

namespace VoxInvasion.Runtime.Networking.Protocol.Handlers.Common
{
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
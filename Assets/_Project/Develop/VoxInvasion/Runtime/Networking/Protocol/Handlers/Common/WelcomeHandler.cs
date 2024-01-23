using UnityEngine;
using VoxInvasion.Runtime.Networking.Protocol.Packets;
using VoxInvasion.Runtime.Networking.Protocol.Packets.Authentication.Login;
using VoxInvasion.Runtime.Networking.Protocol.Packets.Authentication.Registration;
using VoxInvasion.Runtime.Networking.Protocol.Packets.Common;

namespace VoxInvasion.Runtime.Networking.Protocol.Handlers.Common
{
    public class WelcomeHandler : IPacketHandler
    {
        public PacketId Id { get; } = PacketId.Welcome;
        public void Execute(IPacket packet, Client client)
        {
            var welcomePacket = (WelcomePacket)packet;
            Debug.Log($"Server message: {welcomePacket.Message}");
        }
    }
}
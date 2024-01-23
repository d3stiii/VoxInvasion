using ProtoBuf;
using UnityEngine;
using VoxInvasion.Runtime.Networking.Packets.Entrance.Login;

namespace VoxInvasion.Runtime.Networking.Packets.Entrance
{
    [ProtoContract]
    public class WelcomePacket : IPacket
    {
        [ProtoMember(1)] public PacketId Id { get; } = PacketId.Welcome;
        [ProtoMember(2)] public string Message { get; set; } = null!;
    }

    public class WelcomeHandler : IPacketHandler
    {
        public PacketId Id { get; } = PacketId.Welcome;

        public void Execute(IPacket packet, Client client)
        {
            var welcomePacket = (WelcomePacket)packet;
            Debug.Log($"Server message: {welcomePacket.Message}");
            client.SendAsync(new LoginRequestPacket() { Username = "dest1", Password = "P05012015a" });
        }
    }
}
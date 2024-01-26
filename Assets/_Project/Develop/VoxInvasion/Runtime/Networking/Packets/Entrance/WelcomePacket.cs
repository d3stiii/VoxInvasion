using ProtoBuf;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            SceneManager.LoadScene("Entrance");
        }
    }
}
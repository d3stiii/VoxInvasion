using ProtoBuf;
using UnityEngine;
using UnityEngine.SceneManagement;
using VContainer;

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
        private ThreadService _threadService;
        public PacketId Id { get; } = PacketId.Welcome;

        public void Execute(IPacket packet, Client client)
        {
            var welcomePacket = (WelcomePacket)packet;
            Debug.Log($"Server message: {welcomePacket.Message}");
            _threadService.ExecuteInMainThread(() => SceneManager.LoadScene("Entrance"));
            // client.SendAsync(new LoginRequestPacket() { Username = "dest1", Password = "P05012015a" });
        }

        [Inject]
        public void Construct(ThreadService threadService)
        {
            _threadService = threadService;
        }
    }
}
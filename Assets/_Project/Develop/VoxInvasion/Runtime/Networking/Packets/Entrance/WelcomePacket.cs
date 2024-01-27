using ProtoBuf;
using UnityEngine;
using UnityEngine.SceneManagement;
using VContainer;
using VoxInvasion.Runtime.Services.Common;

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
        private SceneLoader _sceneLoader;
        public PacketId Id { get; } = PacketId.Welcome;

        public void Execute(IPacket packet, Client client)
        {
            var welcomePacket = (WelcomePacket)packet;
            Debug.Log($"Server message: {welcomePacket.Message}");
            _sceneLoader.Load("Entrance");
        }

        [Inject]
        public void Construct(SceneLoader sceneLoader) => 
            _sceneLoader = sceneLoader;
    }
}
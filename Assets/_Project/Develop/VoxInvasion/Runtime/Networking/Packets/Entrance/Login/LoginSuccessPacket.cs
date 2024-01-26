using ProtoBuf;
using UnityEngine.SceneManagement;
using VContainer;

namespace VoxInvasion.Runtime.Networking.Packets.Entrance.Login
{
    [ProtoContract]
    public class LoginSuccessPacket : IPacket
    {
        [ProtoMember(1)] public PacketId Id { get; } = PacketId.LoginSuccess;
    }

    public class LoginSuccessHandler : IPacketHandler
    {
        private ThreadService _threadService;
        public PacketId Id { get; } = PacketId.LoginSuccess;

        public void Execute(IPacket packet, Client client)
        {
            SceneManager.LoadScene("_Project/Scenes/SampleScene");
        }

        [Inject]
        public void Construct(ThreadService threadService)
        {
            _threadService = threadService;
        }
    }
}
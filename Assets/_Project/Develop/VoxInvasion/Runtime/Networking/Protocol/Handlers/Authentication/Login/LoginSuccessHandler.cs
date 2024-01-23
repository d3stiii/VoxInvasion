using UnityEngine.SceneManagement;
using VContainer;
using VoxInvasion.Runtime.Networking.Protocol.Packets;

namespace VoxInvasion.Runtime.Networking.Protocol.Handlers.Authentication.Login
{
    public class LoginSuccessHandler : IPacketHandler
    {
        private ThreadService _threadService;
        public PacketId Id { get; } = PacketId.LoginSuccess;

        public void Execute(IPacket packet, Client client)
        {
            _threadService.ExecuteInMainThread(() => SceneManager.LoadScene("_Project/Scenes/SampleScene"));
        }

        [Inject]
        public void Construct(ThreadService threadService)
        {
            _threadService = threadService;
        }
    }
}